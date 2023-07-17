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


            //instance.MapRoute("Citro.Locator.Configuration", $"{LOCATOR_BASE_ROUTE}/Configuration.json", new
            //{
            //    controller = "LocatorConfiguration",
            //    action = "Config"
            //},
            //    namespaces: new[]
            //    {
            //        typeof(XperienceLocatorLocation).Namespace
            //    }
            //);

            instance.MapRoute("XperienceCommuntiy.SearchLocations", $"{LOCATOR_BASE_ROUTE}/Search", new
                {
                    controller = "Locator",
                    action = "Search"
                },
                namespaces: new[]
                {
                    typeof(LocatorLocation).Namespace
                }
            );

            //instance.MapRoute("Citro.Locator.Localization", $"{LOCATOR_BASE_ROUTE}/Localization.json", new
            //{
            //    controller = "Localization",
            //    action = nameof(LocalizationController.Get),
            //},
            //    namespaces: new[]
            //    {
            //        typeof(LocatorConfigurationController).Namespace
            //    }
            //);

            //instance.MapRoute("Citro.Locator.Filters", $"{LOCATOR_BASE_ROUTE}/Filters", new
            //{
            //    controller = "LocatorFilter",
            //    action = nameof(LocatorFilterController.Get)
            //},
            //    namespaces: new[]
            //    {
            //        typeof(LocatorFilterController).Namespace
            //    }
            //);
        }
    }
}
