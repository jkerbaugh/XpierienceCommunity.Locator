using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace XperienceCommunity.Locator.Options
{
    internal class LocatorRouteOptions : IConfigureOptions<MvcOptions>
    {
        public void Configure(MvcOptions options)
        {
            options.Conventions.Add(new LocatorControllerRouteConvention());
        }
    }
}
