using System;
using System.Web;

namespace WebExtension.HttpModule
{
    /// <summary>
    /// write correspond event text to response body
    /// </summary>
    public class LogModule : IHttpModule
    {
        static int LogModuleInstanceCount = 0;
        public static int ApplicationCount = 0;
        public LogModule()
        {
            LogModule.LogModuleInstanceCount++;
        }
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参阅以下链接: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule 成员

        public void Dispose()
        {
            //此处放置清除代码。
        }
        private string ModuleName
        {
            get
            {
                return "LogModule";
            }
        }
        private void LogFlow(HttpApplication app, string message)
        {
            app.Response.Write($"<p>LogModule instanceCount {LogModule.LogModuleInstanceCount}, appCount: {LogModule.ApplicationCount}, {this.ModuleName} log: {message} </p>");
        }
        public void Init(HttpApplication context)
        {
            // 下面是如何处理 LogRequest 事件并为其 
            // 提供自定义日志记录实现的示例
            context.LogRequest += new EventHandler(OnLogRequest);
            context.BeginRequest += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "BeginRequest event");
            });
            context.AuthenticateRequest += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "AuthenticateRequest event");
            });
            context.PostAuthenticateRequest += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostAuthenticateRequest event");
            });
            context.AuthorizeRequest += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "AuthorizeRequest event");
            });
            context.PostAuthorizeRequest += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostAuthorizeRequest event");
            });
            context.ResolveRequestCache += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "ResolveRequestCache event");
            });
            context.PostResolveRequestCache += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostResolveRequestCache event");
            });
            context.MapRequestHandler += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "MapRequestHandler event");
            });
            context.PostMapRequestHandler += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostMapRequestHandler event");
            });
            context.AcquireRequestState += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "AcquireRequestState event");
            });
            context.PostAcquireRequestState += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostAcquireRequestState event");
            });
            context.PreRequestHandlerExecute += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PreRequestHandlerExecute event");
            });
            context.PostRequestHandlerExecute += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostRequestHandlerExecute event");
            });
            context.ReleaseRequestState += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "ReleaseRequestState event");
            });
            context.PostReleaseRequestState += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostReleaseRequestState event");
            });
            context.UpdateRequestCache += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "UpdateRequestCache event");
            });
            context.PostUpdateRequestCache += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PostUpdateRequestCache event");
            });
            context.EndRequest += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "EndRequest event");
            });
            context.PreSendRequestHeaders += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PreSendRequestHeaders event");
            });
            context.PreSendRequestContent += new EventHandler((app, events) =>
            {
                var httpApp = app as HttpApplication;
                LogFlow(httpApp, "PreSendRequestContent event");
            });
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //可以在此处放置自定义日志记录逻辑
        }
    }
}
