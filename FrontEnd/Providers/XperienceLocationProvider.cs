using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationManagement;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator.Providers
{
    internal class XperienceLocationProvider<TModel> : ILocatorDataProvider<TModel>
        where TModel : LocatorLocation, new()
    {
        private readonly ILocationInfoProvider mLocationInfoProvider;
        public XperienceLocationProvider(ILocationInfoProvider mLocationInfoProvider)
        {
            this.mLocationInfoProvider = mLocationInfoProvider;
        }

        public async Task<IEnumerable<TModel>> GetLocationsAsync(LocatorDataQuery request)
        {
            var locations = await mLocationInfoProvider.Get()
                .GetEnumerableTypedResultAsync();

            //todo add filtering and querying

            return locations.Select(_ =>
            {
                var model = new TModel();
                model.MapFromInfoObject(_);
                return model;
            });
        }
    }
}
