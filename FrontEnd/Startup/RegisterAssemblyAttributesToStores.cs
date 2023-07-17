using System;
using System.Collections.Generic;
using System.Reflection;
using CMS.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator
{
    internal class RegisterAssemblyAttributesToStores : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {

            return app =>
            {
                RegisterFilterComponents(app);

                next(app);
            };
        }

        private static void RegisterFilterComponents(IApplicationBuilder builder)
        {
            var factory = builder.ApplicationServices.GetRequiredService<ILocatorDefinitionStoreFactory>();
            var assemblies = AssemblyDiscoveryHelper.GetAssemblies(true);

            factory.StoreAll<RegisterLocatorFilterComponentAttribute>(assemblies);

         
        }

        private void RegisterLocatorFilters(IServiceProvider provider, IEnumerable<Assembly> assemblies)
        {
            var store = provider.GetRequiredService<ILocatorComponentDefinitionStore<LocatorFilterComponentDefinition>>();
            var registeredFilters = assemblies.GetAssemblyAttributes<RegisterLocatorFilterComponentAttribute>();

            
        }
    }
}
