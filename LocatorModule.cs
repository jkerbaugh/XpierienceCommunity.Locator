using CMS;
using XperienceCommunity.Locator;

[assembly: RegisterModule(typeof(LocatorModule))]

namespace XperienceCommunity.Locator
{
    public class LocatorModule : CMS.DataEngine.Module
    {
        public LocatorModule() : base(nameof(LocatorModule))
        {
            
        }

    }
}
