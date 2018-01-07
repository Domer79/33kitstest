using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CommonContracts;
using _33kits.Contracts.Poco;
using FileInfo = _33kits.Contracts.Poco.FileInfo;

namespace _33Kits.DataRepository
{
    /// <summary>
    /// Binary helper
    /// <inheritdoc cref="https://msdn.microsoft.com/ru-ru/library/hh556234%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396"/>
    /// </summary>
    public class BinaryHelper
    {
        private readonly ICommonDb _commonDb;

        public BinaryHelper(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        // Application retrieving a large BLOB from SQL Server in .NET 4.5 using the new asynchronous capability
        public async Task<BinaryDataModel> GetBinaryDataModel(Guid id)
        {
            using (var connection = (SqlConnection)_commonDb.GetConnection())
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT fileName, [data] FROM [FileSystem] WHERE [id]=@id", connection))
                {
                    command.Parameters.AddWithValue("id", id);

                    var dataModel = new BinaryDataModel();
                    // The reader needs to be executed with the SequentialAccess behavior to enable network streaming
                    // Otherwise ReadAsync will buffer the entire BLOB into memory which can cause scalability issues or even OutOfMemoryExceptions
                    using (var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                    {
                        if (await reader.ReadAsync())
                        {
                            dataModel.FileName = (string)reader[0];
                            dataModel.Stream = Stream.Null;

                            if (!(await reader.IsDBNullAsync(0)))
                            {
                                using (var data = reader.GetStream(1))
                                {
                                    var ms = new MemoryStream();
                                    data.CopyTo(ms);
                                    dataModel.Stream = ms;
                                }
                            }

                            var tcs = new TaskCompletionSource<BinaryDataModel>();
                            tcs.SetResult(dataModel);
                            return await tcs.Task;
                        }

                        throw new FileNotFoundException("Файл не найден");
                    }
                }
            }
        }

        public async Task<FileInfo> SaveBinary(string fileName, Stream stream)
        {
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, bytes.Length);

            var hash = GetSHA1HashFromFile(bytes);
            var fileInfo = GetFileInfo(hash, _commonDb);
            if (fileInfo != null)
                throw new DuplicateFileException(fileInfo);

            using (var conn = (SqlConnection) _commonDb.GetConnection())
            {

                await conn.OpenAsync();
                using (var cmd = new SqlCommand("INSERT INTO FileSystem (id, fileName, hash, data) VALUES (@id, @fileName, @hash, @data)" ,conn))
                {
                    var id = Guid.NewGuid();
                    cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                    cmd.Parameters.Add("fileName", SqlDbType.NVarChar, 100).Value = fileName;
                    cmd.Parameters.Add("hash", SqlDbType.NVarChar, 100).Value = hash;
                    cmd.Parameters.Add("@data", SqlDbType.Binary, -1).Value = bytes;

                    // Send the data to the server asynchronously
                    await cmd.ExecuteNonQueryAsync();
                    return new FileInfo(){Id = id, FileName = fileName, Hash = hash};
                }
            }
        }

        internal static FileInfo GetFileInfo(string hash, ICommonDb commonDb)
        {
            return commonDb.Query<FileInfo>("select id, filename, hash from FileSystem where hash = @hash", new {hash}).FirstOrDefault();
        }

        internal static FileInfo GetFileInfo(Guid id, ICommonDb commonDb)
        {
            return commonDb.Query<FileInfo>("select id, filename, hash from FileSystem where id = @id", new {id}).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <inheritdoc cref="https://www.teimouri.net/calculate-file-checksum-in-c/#.Wk6Lr99l9aQ"/>
        /// <returns></returns>
        private static string GetMD5HashFromFile(byte[] bytes)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(bytes);

            var sb = new StringBuilder();
            for (var i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <inheritdoc cref="https://www.teimouri.net/calculate-file-checksum-in-c/#.Wk6Lr99l9aQ"/>
        /// <returns></returns>
        private static string GetSHA1HashFromFile(byte[] bytes)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            var retVal = sha1.ComputeHash(bytes);

            var sb = new StringBuilder();
            for (var i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
