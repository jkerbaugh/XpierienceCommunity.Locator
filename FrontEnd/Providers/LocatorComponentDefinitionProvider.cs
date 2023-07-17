using System.Collections.Generic;
using System.Linq;
using CMS.Core;

namespace XperienceCommunity.Locator
{
    internal class LocatorComponentDefinitionProvider<TDefinition> : ILocatorComponentDefinitionProvider<TDefinition> where TDefinition : BaseLocatorDefinition
    {
        private readonly ILocatorComponentDefinitionStore<TDefinition> mComponentDefinitionStore; 
        private readonly IEventLogService mEventLogService;

        public LocatorComponentDefinitionProvider(ILocatorComponentDefinitionStore<TDefinition> componentDefinitionStore,
            IEventLogService eventLogService)
        {
            mComponentDefinitionStore = componentDefinitionStore;
            mEventLogService = eventLogService;
        }

        public IEnumerable<TDefinition> GetAll()
        {
            var definitions = mComponentDefinitionStore.GetAll();
            if (!definitions.Any())
                return Enumerable.Empty<TDefinition>();

            //todo license validation check

            mEventLogService.LogWarning(nameof(LocatorComponentDefinitionProvider<TDefinition>), "LICENSELIMITATION", "Feature is not available in the current license.");
            return Enumerable.Empty<TDefinition>();
        }
    }
}
