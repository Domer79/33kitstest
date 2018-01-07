using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using _33kits.WebApi.App_Start;
using Autofac;
using Autofac.Extras.NLog;
using Autofac.Integration.WebApi;

namespace _33kits.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            IocConfig.Configure(builder);

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
