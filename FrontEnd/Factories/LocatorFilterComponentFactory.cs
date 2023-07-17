using System;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    public interface ILocatorFilterComponentFactory
    {
        LocatorFilterComponent CreateComponent(LocatorFilterComponentDefinition componentDefinition, LocatorFilterComponentProperties properties);
    }

    public class LocatorFilterComponentFactory : ILocatorFilterComponentFactory
    {
        private readonly IServiceProvider provider;
        public LocatorFilterComponentFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public LocatorFilterComponent CreateComponent(LocatorFilterComponentDefinition definition, LocatorFilterComponentProperties properties)
        {
            if (definition == null)
                throw new ArgumentNullException(nameof(definition));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));
     
            var component = (LocatorFilterComponent) ActivatorUtilities.CreateInstance(provider, definition.FilterComponentType);
            var renderingConfiguration = (LocatorControlRenderingConfiguration)Activator.CreateInstance(definition
                .FilterRenderingConfigurationType);

            //component.BindContext(context);
            component.ComponentDefinition = definition;
            component.RenderingConfiguration = renderingConfiguration;
            component.LoadProperties(properties);
                
            return component;
        }

  
    }
}
