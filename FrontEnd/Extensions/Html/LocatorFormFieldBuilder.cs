using CMS.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace XperienceCommunity.Locator.Extensions.Html
{
    public class LocatorFormFieldBuilder
    {
        private readonly IHtmlHelper helper;
        private readonly LocatorFilterComponent component;

        public LocatorFormFieldBuilder(IHtmlHelper helper, LocatorFilterComponent component)
        {
            this.helper = helper;
            this.component = component;
        }

        public IHtmlContent ValidationMessage()
        {
            IHtmlContentBuilder builder = new HtmlContentBuilder();

            var tag = new TagBuilder("div");

            var message = helper.ValidationMessage(component.Name, null, new
            {
            }, "div");

            tag.InnerHtml.AppendHtml(message);

            return builder
                .AppendHtml(tag);
        }

        public FilterFormWrapperElement BeginWrapper()
        {
            var wrapper = new FilterFormWrapperElement(helper.ViewContext, component);

            var tagBuilder = new TagBuilder(component.RenderingConfiguration.WrapperElement);

            tagBuilder.MergeAttributes(component.RenderingConfiguration.WrapperHtmlAttributes);

            tagBuilder.TagRenderMode = TagRenderMode.StartTag;

            tagBuilder.WriteTo(helper.ViewContext.Writer, HtmlEncoder.Default);

            return wrapper;
        }

        public IHtmlContent Label()
        {
            IHtmlContentBuilder builder = new HtmlContentBuilder();

            string text = ResHelper.LocalizeString(component.BaseProperties.Label);
            if (string.IsNullOrEmpty(text))
                return HtmlString.Empty;

            var htmlAttributes = component.RenderingConfiguration.LabelHtmlAttributes;

            var tag = new TagBuilder("label");

            if (!htmlAttributes.ContainsKey("for"))
            {
                var fullName = helper.ViewData.TemplateInfo.GetFullHtmlFieldName(helper.GenerateIdFromName(component.Name + "." + component.LabelForPropertyName));
                var idFromName = helper.GenerateIdFromName(fullName);
                htmlAttributes.Add("for", idFromName);
            }

            tag.MergeAttributes(htmlAttributes);
            tag.InnerHtml.SetContent(text);

            return builder.AppendHtml(tag);
        }

        public async Task<IHtmlContent> EditorAsync()
        {
            if (helper == null)
                throw new ArgumentNullException(nameof(helper));
            if (component == null)
                throw new ArgumentNullException(nameof(component));
            if (string.IsNullOrEmpty(component.Name))
                throw new ArgumentException("The filter component must have its 'Name' property set in order to render an editor.");

            helper.ViewData.Locator().AddEditorHtmlAttributes(component.RenderingConfiguration.EditorHtmlAttributes);

            var partialViewName = string.IsNullOrEmpty(component.ComponentDefinition.ViewName) ? "FilterComponents/_" + component.ComponentDefinition.Identifier : component.ComponentDefinition.ViewName;
            var fullHtmlFieldName = helper.ViewData.TemplateInfo.GetFullHtmlFieldName(component.Name);

            return await helper.PartialAsync(partialViewName, component, new ViewDataDictionary(helper.ViewData)
            {
                TemplateInfo = {
                    HtmlFieldPrefix = fullHtmlFieldName
                }
            });
        }

        public IHtmlContent HelpText()
        {
            IHtmlContentBuilder builder = new HtmlContentBuilder();
            var text = ResHelper.LocalizeString(component.BaseProperties.HintText);
            if (string.IsNullOrEmpty(text))
                return HtmlString.Empty;

            var tag = new TagBuilder("span");


            var fullName = helper.ViewData.TemplateInfo.GetFullHtmlFieldName(helper.GenerateIdFromName(component.Name + "." + component.LabelForPropertyName + "HelpText"));
            var idFromName = helper.GenerateIdFromName(fullName);
            tag.Attributes.Add("id", idFromName);

            tag.InnerHtml.SetContent(text);
            tag.AddCssClass("text-muted");
            builder = builder.AppendHtml(tag);

            return builder;
        }
    }
}
