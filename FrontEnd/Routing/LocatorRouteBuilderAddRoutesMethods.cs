using System;
using XperienceCommunity.Locator.Extensions;
using static XperienceCommunity.Locator.LocatorConstants;

namespace XperienceCommunity.Locator
{
    public static class RouteBuilderAddRoutesMethods
    {
        public static void MapRoutes(this LocatorRouteBuilderExtensionPoint instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            instance.MapRoute("XperienceCommuntiy.SearchLocations", $"{LOCATOR_BASE_ROUTE}/Search", new
                {
                    controller = "XperienceLocator",
                    action = "Search"
                },
                namespaces: new[]
                {
                    typeof(XperienceLocatorController<>).Namespace
                }
            );
        }
    }
}
