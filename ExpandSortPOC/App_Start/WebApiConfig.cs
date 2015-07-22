using System.Net.Http.Formatting;
using System.Web.Http;

namespace ExpandSortPOC
{
    /// <summary>
    /// Shared configuration across all OData services
    ///
    /// See also for OData version specific setup.
    /// ExpandSortPOC.IEP_CS_OData_Template.Controllers.OData3.WebApiConfig
    /// ExpandSortPOC.IEP_CS_OData_Template.Controllers.OData4.WebApiConfig
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable formatters (XML and JSON)
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("$format", "json", "application/json"));
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("$format", "xml", "application/xml"));
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("$format", "atom", "application/xml+atom"));
        }
    }
}