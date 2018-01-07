using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Autofac.Extras.NLog;
using _33kits.WebApi.Infrastructure;
using _33Kits.DataRepository;
using FileInfo = _33kits.Contracts.Poco.FileInfo;

namespace _33kits.WebApi.Controllers
{
    [RoutePrefix("api/files")]
    public class UploadController : ApiController
    {
        private readonly ILogger _logger;
        private readonly BinaryHelper _binaryHelper;

        public UploadController(ILogger logger, BinaryHelper binaryHelper)
        {
            _logger = logger;
            _binaryHelper = binaryHelper;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IHttpActionResult> File()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                var files = new List<FileInfo>();
                foreach (var content in filesReadToProvider.Contents)
                {
                    using (var stream = await content.ReadAsStreamAsync())
                    {
                        try
                        {
                            files.Add(await _binaryHelper.SaveBinary(content.Headers.ContentDisposition.FileName.Trim('"'), stream));
                        }
                        catch (DuplicateFileException e)
                        {
                            files.Add(e.FileInfo);
                        }
                    }
                }

                return Ok(files);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        [HttpGet]
        [Route("{id}/getfile")]
        public async Task<HttpResponseMessage> GetFile(Guid id)
        {
            try
            {
                var dataModel = await _binaryHelper.GetBinaryDataModel(id);
                if (dataModel.Stream.CanSeek)
                    dataModel.Stream.Seek(0, SeekOrigin.Begin);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(dataModel.Stream);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"){FileName = dataModel.FileName, Size = dataModel.Stream.Length};
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeHelper.GetMimeType(Path.GetExtension(dataModel.FileName)));
                return response;

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
    }

    public class FileData
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
