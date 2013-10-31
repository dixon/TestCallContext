using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: log4net.Config.XmlConfigurator(Watch = true)] // config is in root web.config

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            log.Info("begin");
            HttpContext.Current.Items["data"] = "what was the path? " + Request.Url.PathAndQuery;
            CallContext.LogicalSetData("data", HttpContext.Current.Items["data"]);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            log.Info("end");
            log.Info(HttpContext.Current.Items["data"] ?? "EMPTY CALL CONTEXT");
        }
    }
}