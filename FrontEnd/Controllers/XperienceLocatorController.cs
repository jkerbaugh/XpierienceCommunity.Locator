using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator
{
    [LocatorGenericController]
    public class XperienceLocatorController<TModel> : Controller 
        where TModel : LocatorLocation
    {
        private readonly ILocatorLocationsService<TModel> locatorLocationsService;
        public XperienceLocatorController(ILocatorLocationsService<TModel> locatorLocationsService)
        {
            this.locatorLocationsService = locatorLocationsService;
        }

        [HttpPost]
        public async Task<IActionResult> Search(LocatorDataQuery filter)
        {
            var results = await locatorLocationsService.RetrieveLocations(filter, HttpContext.RequestAborted);
            return Content(JsonConvert.SerializeObject(results, SerializerHelper.GetDefaultSerializerSettings()), "application/json");
        }
    }
}
