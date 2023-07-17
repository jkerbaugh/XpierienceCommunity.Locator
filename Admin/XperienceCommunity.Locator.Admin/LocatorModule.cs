using CMS;
using XperienceCommunity.Locator.Admin;

[assembly: RegisterModule(typeof(LocatorModule))]

namespace XperienceCommunity.Locator.Admin
{
    public class LocatorModule : CMS.DataEngine.Module
    {
        public LocatorModule() : base("XperienceCommunity.Locator.Admin")
        {
            
        }

    }
}
