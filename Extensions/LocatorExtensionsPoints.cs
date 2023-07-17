using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using XperienceCommunity.Locator.Extensions;

namespace XperienceCommunity.Locator
{
    public static class LocatorExtensionsPoints
    {
        public static LocatorRouteBuilderExtensionPoint Locator(this IEndpointRouteBuilder target) => new LocatorRouteBuilderExtensionPoint(target);
        
        public static LocatorHtmlHelperExtensionPoint Locator(this IHtmlHelper helper) => new LocatorHtmlHelperExtensionPoint(helper);

        public static LocatorViewDataExtensionPoint Locator(this ViewDataDictionary vewData) => new LocatorViewDataExtensionPoint(vewData);

    }
}
