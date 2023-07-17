using System;
using System.Collections.Generic;
using System.Reflection;

namespace XperienceCommunity.Locator.Interfaces
{
    internal interface ILocatorDefinitionStoreFactory
    {
        public void StoreAll<TAttribute>(IEnumerable<Assembly> assemblies) where TAttribute : BaseLocatorRegistrationAttribute;
    }
}
