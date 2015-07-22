using System.Net.Http;
using System.Web.Http.OData.Extensions;

namespace ExpandSortPOC.Helpers
{
    /// <summary>
    /// OData V3 specific helper functions, handles interaction with OData libraries for
    /// classes which are common to the application making it impossible to include the
    /// library in the class.
    /// </summary>
    public static class ODataV3Helper
    {
        /// <summary>
        /// Determines the route name which was triggered, route names are defined during creation.
        /// See WebApiConfig.cs for route definitions.
        /// </summary>
        /// <param name="request">The users HTTP requests</param>
        /// <returns>Name of the route</returns>
        public static string GetRouteName(HttpRequestMessage request)
        {
            return request.ODataProperties().RouteName;
        }
    }
}