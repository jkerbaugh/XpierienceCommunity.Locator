using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XperienceCommunity.Locator.Models;

namespace XperienceCommunity.Locator.Interfaces
{
    public interface ILocatorLocationsService<TModel> where TModel : LocatorLocation
    {
        Task<LocatorPagedResponse<IEnumerable<TModel>>> RetrieveLocations(LocatorDataQuery request, CancellationToken cancellationToken);
    }
}
