using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace XperienceCommunity.Locator
{
    public class LocatorOptions : IPostConfigureOptions<LocatorOptions>
    {
        public const string SECTION_NAME = "Locator";
        public string ApiKey { get; set; }
        public string ApiVersion { get; set; } = "weekly";
        public string DistanceFormat { get; set; } = "miles";
        public double Latitude { get; set; } = 35.249160d;
        public double Longitude { get; set; } = -41.548563d;
        public IEnumerable<string> Countries { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Types { get; set; } = Enumerable.Empty<string>();
        public bool StrictBounds { get; set; } = false;

        public void PostConfigure(string name, LocatorOptions options)
        {
            //ApiKey = SettingsKeyInfoProvider.GetValue($"{SiteContext.CurrentSiteName}.LocatorApiKey");
        }
    }
}
