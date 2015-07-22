using ExpandSortPOC.Helpers.ControllerSelector;
using ExpandSortPOC.Models.v1;
using Microsoft.OData.Edm;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Formatter;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;

namespace ExpandSortPOC.Controllers.OData4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // OData 4 specific formatters
            //var formatters = ODataMediaTypeFormatters.Create();
            // Insert the OData formatters at the start of the collection.
            //config.Formatters.InsertRange(0, formatters);

            // Create the default collection of built-in conventions.
            var conventions = ODataRoutingConventions.CreateDefault();
            // Insert any custom routing conventions at the start of the collection.
            // Example: conventions.Insert(0, new MyCustomRoutingConvention());

            // OData V4 route definition
            config.MapODataServiceRoute("ODataV4Route", "odata4/v1", GetModel(), new DefaultODataPathHandler(),
                conventions);

            var controllerSelector = config.Services.GetService(typeof(IHttpControllerSelector)) as ODataVersionControllerSelector;
            Debug.Assert(controllerSelector != null, "controllerSelector != null"); // Should never be null
            controllerSelector.RouteVersionSuffixMapping.Add("ODataV4Route", "V4_1");
        }

        private static IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();

            // Define the OData end points
            // ie: builder.EntitySet<Artist>("Artists");
            builder.EntitySet<PocCntry>("PocCntry").EntityType.HasKey(a => new { a.CntryId });
            builder.EntitySet<PocSubject>("PocSubject").EntityType.HasKey(a => new { a.SiteId, a.ClnclId });

            return builder.GetEdmModel();
        }
    }
}