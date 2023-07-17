using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace XperienceCommunity.Locator
{
    public class LocatorFilterFormTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        private readonly ILocatorComponentDefinitionStore<LocatorFilterComponentDefinition> mComponentDefinitionStore;
        private readonly IHtmlHelper mHtmlHelper;
        private readonly ILocatorFilterComponentFactory mFilterComponentFactory;
        private readonly ILocatorFilterPropertiesFactory mFilterPropertiesFactory;
        public LocatorFilterFormTagHelper(
            IHtmlHelper htmlHelper,
            ILocatorFilterComponentFactory filterComponentFactory,
            ILocatorComponentDefinitionStore<LocatorFilterComponentDefinition> componentDefinitionStore, ILocatorFilterPropertiesFactory filterPropertiesFactory)
        {
            mHtmlHelper = htmlHelper;
            mComponentDefinitionStore = componentDefinitionStore;
            mFilterPropertiesFactory = filterPropertiesFactory;
            mFilterComponentFactory = filterComponentFactory;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (output == null)
                throw new ArgumentNullException(nameof(output));


            ((IViewContextAware)mHtmlHelper).Contextualize(ViewContext);


            var components = GetFilterComponents();

            output.Content.SetHtmlContent(await mHtmlHelper.PartialAsync("~/Views/Shared/Locator/_FilterForm.cshtml", components));

        }

        private IEnumerable<LocatorFilterComponent> GetFilterComponents()
        {
            var definitions = mComponentDefinitionStore.GetAll();

            foreach (var definition in definitions)
            {
                var properties = mFilterPropertiesFactory.CreateProperties(definition);
                var component = mFilterComponentFactory.CreateComponent(definition, properties);

                component.Name = definition.Name;
                var defaultValue = properties.GetDefaultValue();
                if (defaultValue != null)
                    component.SetValueInternal(defaultValue);

                yield return component;
            }
        }
    }
}
