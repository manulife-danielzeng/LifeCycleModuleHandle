using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeCycleModuleHandle
{
    public class CustomHandlerFactory : IHttpHandlerFactory
    {
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            IHttpHandler handlerToReturn = null;
            if (url.EndsWith(".sample") || url.EndsWith(".bb"))
            {
                handlerToReturn = new CustomHandler();
            }
            else if (url.EndsWith(".iis"))
            {
                handlerToReturn = new IISHandler1();
            }
            return handlerToReturn;
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
        }
    }
}