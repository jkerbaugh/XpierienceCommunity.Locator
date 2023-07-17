using System;
using CMS.Helpers;
using XperienceCommunity.Locator.Models;

namespace XperienceCommunity.Locator
{
    public sealed class RegisterLocatorFilterComponentAttribute : BaseLocatorRegistrationAttribute
    {
        public string ViewName { get; set; }

        public Type FilterRenderingConfigurationType { get; internal set; }

        public RegisterLocatorFilterComponentAttribute(string identifier, Type filterComponentType, string name) 
            : base(identifier, filterComponentType, name)
        {
        }

        public RegisterLocatorFilterComponentAttribute(string identifier, Type filterComponentType, Type filterRenderingConfiguration, string name)
            : base(identifier, filterComponentType, name)
        {
            FilterRenderingConfigurationType = filterRenderingConfiguration;
        }


        internal LocatorFilterComponentDefinition CreateDefinition()
        {
            FilterRenderingConfigurationType ??= typeof(LocatorControlRenderingConfiguration);

            var componentDefinition = new LocatorFilterComponentDefinition(Identifier, MarkedType, FilterRenderingConfigurationType, Name);
            
            if (string.IsNullOrWhiteSpace(ViewName))
                componentDefinition.ViewName = $"~/Views/Shared/Locator/FilterComponents/_{ValidationHelper.GetIdentifier(Identifier)}.cshtml";
            else
                componentDefinition.ViewName = ViewName;

            return componentDefinition;
        }
    }
}
