using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XperienceCommunity.Locator.Interfaces;
using XperienceCommunity.Locator.Models;

namespace XperienceCommunity.Locator.Services
{
    internal class LocatorLocationsService<TModel> : ILocatorLocationsService<TModel> where TModel : LocatorLocation
    {
        private readonly IEnumerable<ILocatorDataProvider<TModel>> dataProviders;

        public LocatorLocationsService(IEnumerable<ILocatorDataProvider<TModel>> dataProviders)
        {
            this.dataProviders = dataProviders;
        }

        public async Task<LocatorPagedResponse<IEnumerable<TModel>>> RetrieveLocations(LocatorDataQuery request, CancellationToken cancellationToken)
        {
            var tasks = dataProviders.Select(_ => _.GetLocationsAsync(request)).ToList();

            var results = new List<TModel>();
            foreach (var bucket in tasks.Interleaved())
            {
                var t = await bucket;
                results.AddRange(await t);
                results.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            }

            var recordCount = new RecordsCount
            {
                RecordsTotal = results.Count,
                RecordsFiltered = request.PageSize
            };

            results = results
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new LocatorPagedResponse<IEnumerable<TModel>>(results, request.PageNumber, request.PageSize, recordCount);
        }
    }
}
