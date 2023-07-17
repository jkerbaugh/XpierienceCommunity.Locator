using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator.Providers
{
    internal class XperienceLocationProvider<TModel> : ILocatorDataProvider<TModel>
        where TModel : LocatorLocation, new()
    {
        public async Task<IEnumerable<TModel>> GetLocationsAsync(LocatorDataQuery request)
        {

            return Enumerable.Empty<TModel>();
        }
    }
}
