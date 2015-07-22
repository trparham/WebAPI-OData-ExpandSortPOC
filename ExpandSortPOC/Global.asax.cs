using ExpandSortPOC.Helpers.ControllerSelector;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExpandSortPOC
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            // Custom controller selector to support multiple OData Versions
            var controllerSelector = new ODataVersionControllerSelector(config);
            config.Services.Replace(typeof(IHttpControllerSelector), controllerSelector);

            // The following has dependencies on controllerSelector
            WebApiConfig.Register(config);
            Controllers.OData3.WebApiConfig.Register(config);
            Controllers.OData4.WebApiConfig.Register(config);

            // Default MVC application registrations
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            config.EnsureInitialized();
        }
    }
}