using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeCycleModuleHandle
{
    public class CustomHandler : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Custom handler");
        }
    }
}