using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac.Extras.NLog;
using _33kits.Contracts.Interfaces;
using _33kits.Contracts.Poco;

namespace _33kits.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _repo;
        private readonly ILogger _logger;

        public ProductController(IProductRepository repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: api/Product
        public IEnumerable<Product> Get()
        {
            try
            {
                return _repo.Get();

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        // GET: api/Product/5
        public Product GetById(Guid id)
        {
            try
            {
                return _repo.Get(id);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        public IEnumerable<FileInfo> GetImages(Guid id)
        {
            try
            {
                return _repo.GetProductImages(id);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        // POST: api/Product
        public void Post([FromBody]Product value)
        {
            try
            {
                _repo.Create(value);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        // PUT: api/Product/5
        public void Put(Guid id, [FromBody]Product value)
        {
            try
            {
                _repo.Update(value);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        // DELETE: api/Product/5
        public void Delete(Guid id)
        {
            try
            {
                _repo.Remove(id);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
    }
}
