using System;
using System.Linq;

namespace ExpandSortPOC.Extensions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GatewayAttribute : System.Web.Http.AuthorizeAttribute
    {
        private const string HeaderName = "Entities";
        private string Entity { get; set; }

        public GatewayAttribute(string entity)
        {
            Entity = entity;
        }

        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            return actionContext.Request.Headers.Contains(HeaderName) && actionContext.Request.Headers.GetValues(HeaderName).Contains(Entity);
        }
    }
}