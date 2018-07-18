using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {
            //Global errors to be catched here...
            var ex = Server.GetLastError();
            
            //Log error into db... I am making it as async called... As it returns void (fire and forget)
            Action a = new Action(() => { Utility.ErrorSave._getInstance.Log(ex); });

            System.Threading.Tasks.Task.Factory.StartNew(a);
        }
    }
}
