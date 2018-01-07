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
    [RoutePrefix("api/dish")]
    public class DishController : ApiController
    {
        private readonly IDishRepository _repo;
        private readonly ILogger _logger;

        public DishController(IDishRepository repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: api/Dish
        public IEnumerable<Dish> Get()
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

        [Route("{id}/getdish")]
        public Dish GetById(Guid id)
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

        [Route("{idMenu}/except")]
        public IEnumerable<Dish> GetDishesExcept(Guid idMenu)
        {
            try
            {
                return _repo.GetDishesExcept(idMenu);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        [Route("{id}/getimages")]
        public IEnumerable<FileInfo> GetImages(Guid id)
        {
            try
            {
                return _repo.GetDishImages(id);

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        // POST: api/Dish
        public void Post([FromBody]Dish value)
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

        // PUT: api/Dish/5
        public void Put(Guid id, [FromBody]Dish value)
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

        // DELETE: api/Dish/5
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
