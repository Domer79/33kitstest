using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _33kits.WebApi.Handlers
{
    public class FileStaticHandler: IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var idFile = context.Request.QueryString;
        }

        public bool IsReusable => true;
    }
}