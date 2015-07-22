using System.Diagnostics;
using ExpandSortPOC.Helpers.ControllerSelector;
using Microsoft.Data.Edm;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Formatter;

using ExpandSortPOC.Models.v1;

namespace ExpandSortPOC.Controllers.OData3
{
    public static class WebApiConfig
    {
        /// <summary>
        ///     OData version 3 route definition setup
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // OData 3 specific formatters
            //var formatters = ODataMediaTypeFormatters.Create();
            //config.Formatters.InsertRange(0, formatters);

            // Controller selector to support service versioning
            var controllerSelector = config.Services.GetService(typeof(IHttpControllerSelector)) as ODataVersionControllerSelector;

            // OData 3, Version 1 route definition
            config.Routes.MapODataServiceRoute("ODataV3_1Route", "odata3/v1", GetModel());
            Debug.Assert(controllerSelector != null, "controllerSelector != null"); // Should never be null
            controllerSelector.RouteVersionSuffixMapping.Add("ODataV3_1Route", "V3_1");
        }

        private static IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();

            // Define the OData end points
            // ie: builder.EntitySet<Artist>("Artists");
            builder.EntitySet<PocCntry>("PocCntry").EntityType
                .HasKey(a => new { a.CntryId });
            builder.EntitySet<PocSubject>("PocSubject").EntityType
                .HasKey(a => new {a.SiteId, a.ClnclId});

            return builder.GetEdmModel();
        }
    }
}