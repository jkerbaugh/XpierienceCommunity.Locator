using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using XperienceCommunity.Locator.Extensions.Html;

namespace XperienceCommunity.Locator
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent ValidationSummary(this LocatorHtmlHelperExtensionPoint helper)
        {
            IHtmlContentBuilder builder = new HtmlContentBuilder();

            var tag = new TagBuilder("div");

            tag.InnerHtml.AppendHtml(helper.Instance.ValidationMessage("GeolocationError", ""));
            tag.InnerHtml.AppendHtml(helper.Instance.ValidationMessage("AutoCompleteError", ""));
            tag.InnerHtml.AppendHtml(helper.Instance.ValidationMessage("RequestError", null));

            return builder
                .AppendHtml(tag);
        }

        public static LocatorFormFieldBuilder FormBuilderFor(this LocatorHtmlHelperExtensionPoint helper,
            LocatorFilterComponent component)
        {
            return new LocatorFormFieldBuilder(helper.Instance, component);
        }

        public static async Task<IHtmlContent> FilterFieldsAsync(this LocatorHtmlHelperExtensionPoint helper, IEnumerable<LocatorFilterComponent> components)
        {
            //FormExtensions.ValidateParameters(htmlHelper, formComponents);
            IHtmlContentBuilder builder = new HtmlContentBuilder();

            foreach (var component in components)
            {
                var content = await helper.FilterFieldAsync(component);
                builder = builder.AppendHtml(content);
            }

            return builder;
        }

        public static async Task<IHtmlContent> FilterFieldAsync(this LocatorHtmlHelperExtensionPoint helper, LocatorFilterComponent component)
        {
            return await helper.Instance.PartialAsync("~/Views/Shared/Locator/_FilterComponent.cshtml", component);
        }

        public static async Task<IHtmlContent> SubmitAsync(this LocatorHtmlHelperExtensionPoint helper)
        {
            var tag = new TagBuilder("button");
            tag.Attributes.Add("type", "submit");

            tag.AddCssClass("btn btn-primary mt-2");

            tag.InnerHtml.SetHtmlContent("Submit");

            return new HtmlContentBuilder().AppendHtml(tag);
        }
    }
}
