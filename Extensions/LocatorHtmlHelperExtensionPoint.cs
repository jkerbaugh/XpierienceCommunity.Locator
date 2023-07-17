using Microsoft.AspNetCore.Mvc.Rendering;

namespace XperienceCommunity.Locator
{
    public sealed class LocatorHtmlHelperExtensionPoint
    {
        internal IHtmlHelper Instance;
        public LocatorHtmlHelperExtensionPoint(IHtmlHelper instance)
        {
            Instance = instance;
        }
    }
}
