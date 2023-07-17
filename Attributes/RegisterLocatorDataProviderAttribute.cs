using System;

namespace XperienceCommunity.Locator
{
    internal class RegisterLocatorDataProviderAttribute : BaseLocatorRegistrationAttribute
    {

        protected RegisterLocatorDataProviderAttribute(string identifier, Type filterComponentType, string name) : base(identifier, filterComponentType, name)
        {
        }
    }
}
