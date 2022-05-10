using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Threading.Tasks;
using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(mvc.vuejs.example.App_Start.Bootstrap), "Initialize")]
namespace mvc.vuejs.example
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
    }
}
