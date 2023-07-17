using System.Collections.Generic;

namespace XperienceCommunity.Locator
{
    internal interface ILocatorComponentDefinitionProvider<TDefinition> where TDefinition : BaseLocatorDefinition
    {
        IEnumerable<TDefinition> GetAll();
    }
}