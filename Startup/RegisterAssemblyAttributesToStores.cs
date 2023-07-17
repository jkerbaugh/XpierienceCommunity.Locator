using System;
using System.Collections.Generic;
using System.Reflection;
using CMS.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    internal class RegisterAssemblyAttributesToStores : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            var assemblies = AssemblyDiscoveryHelper.GetAssemblies(true);

            return app =>
            {
                RegisterLocatorFilters(app.ApplicationServices, assemblies);


                next(app);
            };
        }

        private void RegisterLocatorFilters(IServiceProvider provider, IEnumerable<Assembly> assemblies)
        {
            var store = provider.GetRequiredService<ILocatorComponentDefinitionStore<LocatorFilterComponentDefinition>>();
            var registeredFilters = assemblies.GetAssemblyAttributes<RegisterLocatorFilterComponentAttribute>();

            foreach (var filter in registeredFilters)
            {
                store.Add(filter.CreateDefinition());
            }
        }
    }
}
