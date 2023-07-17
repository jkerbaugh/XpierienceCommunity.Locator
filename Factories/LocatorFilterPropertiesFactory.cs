using System;
using CMS.Helpers;

namespace XperienceCommunity.Locator
{
    public interface ILocatorFilterPropertiesFactory
    {
        LocatorFilterComponentProperties CreateProperties(LocatorFilterComponentDefinition definition);
    }

    public class LocatorFilterPropertiesFactory : ILocatorFilterPropertiesFactory
    {
     

        public LocatorFilterComponentProperties CreateProperties(LocatorFilterComponentDefinition definition)
        {
            if (definition == null)
                throw new ArgumentNullException(nameof(definition));

            var properties = (LocatorFilterComponentProperties)Activator.CreateInstance(definition.FilterComponentPropertiesType);

            if (string.IsNullOrEmpty(properties.Label))
                properties.Label = ResHelper.LocalizeString(definition.Name);

            return properties;
        }
    }
}
