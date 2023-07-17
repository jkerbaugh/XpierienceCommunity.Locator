using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using static XperienceCommunity.Locator.LocatorConstants;

namespace XperienceCommunity.Locator
{
    internal class LocatorControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {

            var attribute = controller.ControllerType.GetCustomAttribute<LocatorGenericControllerAttribute>();
            if (attribute != null)
            {
                controller.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel =
                        new AttributeRouteModel(new RouteAttribute($"{LOCATOR_BASE_ROUTE}/Search")),
                });
            }
        }
    }
}
