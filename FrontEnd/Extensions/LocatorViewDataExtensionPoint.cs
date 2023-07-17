using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace XperienceCommunity.Locator
{
    public class LocatorViewDataExtensionPoint
    {
        public ViewDataDictionary Instance;

        public LocatorViewDataExtensionPoint(ViewDataDictionary viewData)
        {
            Instance = viewData;
        }
    }
}
