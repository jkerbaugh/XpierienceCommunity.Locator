using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Options;

namespace XperienceCommunity.Locator
{
    public class LocatorOptions
    {
        public const string SECTION_NAME = "Locator";

        [Required] 
        public string ApiKey { get; set; }

        [Required] public string ApiVersion { get; set; } 
            = "weekly";

        public string DistanceFormat { get; set; } = "miles";
        public double Latitude { get; set; } = 35.249160d;
        public double Longitude { get; set; } = -41.548563d;
        public IEnumerable<string> Countries { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> Types { get; set; } = Enumerable.Empty<string>();
        public bool StrictBounds { get; set; } = false;
    }
}
