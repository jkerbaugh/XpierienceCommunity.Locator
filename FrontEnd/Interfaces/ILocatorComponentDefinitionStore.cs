using System.Collections.Generic;

namespace XperienceCommunity.Locator
{
    public interface ILocatorComponentDefinitionStore<TDefinition> where TDefinition : BaseLocatorDefinition
    {
        IEnumerable<TDefinition> GetAll();

        TDefinition Get(string identifier);

        void Add(TDefinition registeredDefinition);
    }
}