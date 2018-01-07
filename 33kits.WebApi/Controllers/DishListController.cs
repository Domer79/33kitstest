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
    [RoutePrefix("api/dishlist")]
    public class DishListController : ApiController
    {
        private readonly IDishListRepository _repo;
        private readonly ILogger _logger;

        public DishListController(IDishListRepository repo, ILogger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: api/DishList
        public IEnumerable<DishList> Get()
        {
            return _repo.Get();
        }


        public IEnumerable<DishList> GetByIdMenu(Guid idMenu)
        {
            return _repo.Get(idMenu);
        }

        // GET: api/DishList/5
        public DishList Get(Guid idMenu, Guid idDish)
        {
            return _repo.Get(idMenu, idDish);
        }

        // POST: api/DishList
        public void Post([FromBody]DishList value)
        {
            _repo.Create(value);
        }

        [HttpPost]
        [Route("CreateMany")]
        public void CreateMany([FromBody] DishList[] dishList)
        {
            _repo.CreateMany(dishList);
        }

        // PUT: api/DishList/5
        public void Put([FromBody]string value)
        {
            throw new NotSupportedException();
        }

        // DELETE: api/DishList/5
        public void Delete(Guid idMenu, Guid idDish)
        {
            _repo.Remove(idMenu, idDish);
        }
    }
}
