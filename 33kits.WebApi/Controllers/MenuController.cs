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
    public class MenuController : ApiController
    {
        private readonly IMenuOnDayRepository _repo;
        private readonly IDishRepository _dishRepo;
        private readonly ILogger _logger;

        public MenuController(IMenuOnDayRepository repo, IDishRepository dishRepo, ILogger logger)
        {
            _repo = repo;
            _dishRepo = dishRepo;
            _logger = logger;
        }

        // GET: api/Menu
        public IEnumerable<MenuOnDay> Get()
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

        // GET: api/Menu/5
        public MenuOnDay GetById(Guid id)
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

        // POST: api/Menu
        public IHttpActionResult Post([FromBody]MenuOnDay value)
        {
            try
            {
                _repo.Create(value);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        // PUT: api/Menu/5
        public IHttpActionResult Put(Guid id, [FromBody]MenuOnDay value)
        {
            try
            {
                _repo.Update(value);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        // DELETE: api/Menu/5
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
