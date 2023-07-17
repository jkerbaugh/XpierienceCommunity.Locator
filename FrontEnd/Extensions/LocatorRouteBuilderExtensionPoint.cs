using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace XperienceCommunity.Locator.Extensions
{
    public sealed class LocatorRouteBuilderExtensionPoint
    {
        internal IEndpointRouteBuilder Endpoints;
        internal LocatorRouteBuilderExtensionPoint(IEndpointRouteBuilder endpoints)
        {
            Endpoints = endpoints;
        }

        internal IEndpointConventionBuilder MapRoute(
            string name,
            string url,
            object defaults = null,
            object constraints = null,
            string[] namespaces = null)
        {
            return namespaces != null && namespaces.Length != 0 ? MapControllerRoute(name, url, defaults, constraints, new
            {
                Namespaces = namespaces
            }) : MapControllerRoute(name, url, defaults, constraints);
        }

        private IEndpointConventionBuilder MapControllerRoute(
            string name,
            string pattern,
            object defaults = null,
            object constraints = null,
            object dataTokens = null)
        {
            return Endpoints.MapControllerRoute(name, pattern, defaults, constraints, dataTokens);
        }
    }
}
