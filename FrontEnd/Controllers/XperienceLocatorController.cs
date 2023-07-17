using Microsoft.AspNetCore.Mvc;

namespace XperienceCommunity.Locator
{
    public class XperienceLocatorController<TModel> : Controller 
        where TModel : LocatorLocation
    {

        public IActionResult Search()
        {

            return Ok();
        }
    }
}
