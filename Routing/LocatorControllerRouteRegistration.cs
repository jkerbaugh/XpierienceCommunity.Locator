using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace XperienceCommunity.Locator
{
    public class LocatorControllerRouteRegistration<TModel> : IApplicationFeatureProvider<ControllerFeature>
        where TModel : LocatorLocation, new()
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var controllerType = typeof(XperienceLocatorController<>);
            var locatorModelType = typeof(TModel);
            var genericControllerType = controllerType.MakeGenericType(locatorModelType);
            feature.Controllers.Add(genericControllerType.GetTypeInfo());
        }
    }
}
