using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator.Factories
{
    internal class LocatorDefinitionStoreFactory : ILocatorDefinitionStoreFactory
    {
        private readonly IServiceProvider provider;
        public LocatorDefinitionStoreFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public void StoreAll<TAttribute>(IEnumerable<Assembly> assemblies) where TAttribute : BaseLocatorRegistrationAttribute
        {
            var registeredFilters = assemblies.SelectMany(_ => _.GetCustomAttributes<TAttribute>());

            foreach (var filter in registeredFilters)
            {
                var definition = filter.CreateDefinition();

                if(definition == null)
                    throw new ArgumentNullException(nameof(definition));

                var type = typeof(ILocatorComponentDefinitionStore<>).MakeGenericType(definition.GetType());
                var definitionStore = provider.GetRequiredService(type);
                var methodInfo = definitionStore.GetType().GetMethod(nameof(ILocatorComponentDefinitionStore<BaseLocatorDefinition>.Add));
                methodInfo?.Invoke(definitionStore, new object[] { definition });
            }
        }
    }
}
