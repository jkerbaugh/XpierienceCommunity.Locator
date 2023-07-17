using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace XperienceCommunity.Locator.TagHelpers
{
    [HtmlTargetElement("locator-autocomplete")]
    public class LocatorAutoCompleteTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var tag = new TagBuilder("input");
            tag.Attributes.Add("type", "search");
            tag.Attributes.Add("id", "locator-autocomplete");
            tag.Attributes.Add("data-locator-autocomplete", null);
            tag.AddCssClass("form-control");

            output.Content.SetHtmlContent(tag);

        }
    }
}
