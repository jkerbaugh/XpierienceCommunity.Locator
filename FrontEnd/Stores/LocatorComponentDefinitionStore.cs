using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace XperienceCommunity.Locator
{
    internal class LocatorComponentDefinitionStore<TDefinition> : ILocatorComponentDefinitionStore<TDefinition>
    where TDefinition : BaseLocatorDefinition
    {
        private readonly ConcurrentDictionary<string, TDefinition> mDefinitionRegistry =
            new ConcurrentDictionary<string, TDefinition>(4, 4, StringComparer.InvariantCultureIgnoreCase);

        public IEnumerable<TDefinition> GetAll()
        {
            return mDefinitionRegistry.Values;
        }

        /// <summary>
        /// Gets a registered componentDefinition by its <see cref="P:Kentico.Content.Web.Mvc.IDefinition.Identifier" />.
        /// </summary>
        /// <param name="identifier">Identifier of the registered componentDefinition to retrieve.</param>
        /// <returns>Returns registered componentDefinition with given identifier, or null when not found.</returns>
        public TDefinition Get(string identifier)
        {
            return mDefinitionRegistry.TryGetValue(identifier, out var definition) ? definition : default(TDefinition);
        }

        /// <summary>Adds a componentDefinition to a appropriate store.</summary>
        /// <param name="registeredDefinition">ComponentDefinition to register.</param>
        /// <exception cref="T:System.ArgumentNullException"> Is thrown when <paramref name="registeredDefinition" /> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentException"> Is thrown when the store already contains componentDefinition with the same identifier as <paramref name="registeredDefinition" />.</exception>
        public void Add(TDefinition registeredDefinition)
        {
            if (registeredDefinition == null)
                throw new ArgumentNullException(nameof(registeredDefinition));
            if (!mDefinitionRegistry.TryAdd(registeredDefinition.Identifier, registeredDefinition))
                throw new ArgumentException("ComponentDefinition with key '" + registeredDefinition.Identifier + "' cannot be registered because another componentDefinition with such key is already present.");
        }


    }
}
