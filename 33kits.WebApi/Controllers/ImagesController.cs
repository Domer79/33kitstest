using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Autofac.Extras.NLog;
using _33kits.Contracts.Interfaces;
using _33kits.WebApi.Infrastructure;
using FileInfo = _33kits.Contracts.Poco.FileInfo;

namespace _33kits.WebApi.Controllers
{
    public class ImagesController : ApiController
    {
        private readonly IImagesRepository _repo;
        private readonly ILogger _logger;

        public ImagesController(IImagesRepository repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IEnumerable<FileInfo> Get()
        {
            try
            {
                return _repo.GetImagesInfo();

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        public HttpResponseMessage GetResize70Image(Guid id)
        {
            try
            {
                var dataModel = _repo.GetResizeImage(id, 70, 70);
                if (dataModel.Stream.CanSeek)
                    dataModel.Stream.Seek(0, SeekOrigin.Begin);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var content = ((MemoryStream)dataModel.Stream).ToArray();
                response.Content = new ByteArrayContent(content);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = dataModel.FileName, Size = content.Length };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeHelper.GetMimeType(Path.GetExtension(dataModel.FileName)));
                return response;

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        public HttpResponseMessage GetResizeImage(Guid id, int height, int width)
        {
            try
            {
                var dataModel = _repo.GetResizeImage(id, height, width);
                if (dataModel.Stream.CanSeek)
                    dataModel.Stream.Seek(0, SeekOrigin.Begin);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var content = ((MemoryStream)dataModel.Stream).ToArray();
                response.Content = new ByteArrayContent(content);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = dataModel.FileName, Size = content.Length };
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
}
