using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using CommonContracts;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using _33kits.Contracts.Interfaces;
using _33kits.Contracts.Poco;
using FileInfo = _33kits.Contracts.Poco.FileInfo;

namespace _33Kits.DataRepository
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly ICommonDb _commonDb;

        public ImagesRepository(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        public IEnumerable<BinaryDataModel> GetResizeTo70Images(params string[] extensions)
        {
            var imagesInfo = GetImagesInfo(extensions);
            var dataModels = new List<BinaryDataModel>();
            foreach (var fileInfo in imagesInfo)
            {
                var bytes = _commonDb.Query<byte[]>("select data from FileSystem where id = @id", new {id = fileInfo.Id}).First();
                var resizeStream = ResizeTo70(bytes);
                dataModels.Add(new BinaryDataModel(){Id = fileInfo.Id, FileName = fileInfo.FileName, Stream = resizeStream});
            }

            return dataModels;
        }

        public IEnumerable<FileInfo> GetImagesInfo(params string[] extensions)
        {
            var filter = "";
            if (extensions != null && extensions.Length != 0)
            {
                var list = extensions.ToList();
                var firstExtension = list[0];
                list.RemoveAt(0);
                filter = $"where ext in ({list.Aggregate(firstExtension, (c, n) => $"{c},'{n}'")}";
            }

            var query = $@"select
	id, fileName, hash
from
(
	select id, fileName, hash, data, substring(fileName, len(fileName) - PATINDEX('%.%', REVERSE(fileName))+1, PATINDEX('%.%', REVERSE(fileName))+1) as ext from FileSystem
)s1 {filter}";

            return _commonDb.Query<FileInfo>(query);
        }

        public IEnumerable<FileInfo> GetImagesInfo(Guid[] ids)
        {
            if (ids == null || ids.Length == 0)
                throw new ArgumentException(nameof(ids));

            return _commonDb.Query<FileInfo>("select id, fileName, hash from FileSystem where id in @ids", new{ids});
        }

        public BinaryDataModel GetResizeImage(Guid id, int height, int width)
        {
            var fileInfo = BinaryHelper.GetFileInfo(id, _commonDb);
            var bytes = _commonDb.Query<byte[]>("select data from FileSystem where id = @id", new { id = fileInfo.Id }).First();
            return new BinaryDataModel(){Id = fileInfo.Id, FileName = fileInfo.FileName, Stream = GetResizeImageStream(bytes, height, width)};
        }

        private Stream ResizeTo70(byte[] imageData)
        {
            return GetResizeImageStream(imageData, 70, 70);
        }

        private static Stream GetResizeImageStream(byte[] imageData, int height, int width)
        {
            ISupportedImageFormat format = new JpegFormat {Quality = 70};
            Size size = new Size(width, height);
            using (MemoryStream inStream = new MemoryStream(imageData))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        // Load, resize, set the format and quality and save an image.
                        imageFactory.Load(inStream)
                            .Resize(size)
                            .Format(format)
                            .Save(outStream);

                        return outStream;
                    }
                    // Do something with the stream.
                }
            }
        }
    }
}