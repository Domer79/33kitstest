using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac.Extras.NLog;
using CommonContracts;
using Migrator.Migrations;

namespace _33kits.WebApi.Controllers
{
    [RoutePrefix("api/system")]
    public class SystemController : ApiController
    {
        private readonly IMigrator _migrator;
        private readonly ILogger _logger;

        public SystemController(IMigrator migrator, ILogger logger)
        {
            _migrator = migrator;
            _logger = logger;
        }

        [Route("migration/up")]
        [HttpGet]
        public IHttpActionResult MigrationUp()
        {
            try
            {
                _migrator.Up();
                return Ok(new {Result = "Ok!"});

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }
    }
}
