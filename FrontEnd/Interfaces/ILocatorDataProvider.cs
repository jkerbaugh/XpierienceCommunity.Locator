using System.Collections.Generic;
using System.Threading.Tasks;

namespace XperienceCommunity.Locator.Interfaces
{
    public interface ILocatorDataProvider<TModel> where TModel : LocatorLocation
    {
        Task<IEnumerable<TModel>> GetLocationsAsync(LocatorDataQuery request);
    }
}
