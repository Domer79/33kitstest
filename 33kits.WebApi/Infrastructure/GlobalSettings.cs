using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using CommonContracts;

namespace _33kits.WebApi.Infrastructure
{
    public class GlobalSettings: IGlobalSettings
    {
        public string MigrationAssemblyName => "33kits.Migrations";

        public string DefaultConnectionString => ConfigurationManager.ConnectionStrings["cafeathomedb"].ConnectionString;
    }
}