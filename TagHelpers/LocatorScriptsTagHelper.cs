using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace XperienceCommunity.Locator.TagHelpers
{
    public class LocatorScriptsTagHelper : TagHelper
    {
        internal const string BUNDLE_PATH = "~/_content/XperienceCommunity.Locator/locator";

        private readonly IOptions<LocatorOptions> options;

        public LocatorScriptsTagHelper(IOptions<LocatorOptions> options)
        {
            this.options = options;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            output.Content.AppendHtml($@"
                <script>
                window.locator = window.locator || {{}};
                window.locator.settings = window.locator.settings || {{}};
                window.locator.settings.apiKey = '{options.Value.ApiKey}';
                window.locator.settings.apiVersion = '{options.Value.ApiVersion}';
                window.locator.settings.mapPosition = {{
                    lat: {options.Value.Latitude},
                    lng: {options.Value.Longitude}      
                }}
                </script>   
            ");

            var runtimeScript = BuildScriptModuleTag(Path.Combine(BUNDLE_PATH, "main.js"));
            output.Content.AppendHtml(runtimeScript);
        }

        private TagBuilder BuildScriptModuleTag(string source)
        {
            var script = new TagBuilder("script");
            script.Attributes.Add("src", source);
            script.Attributes.Add("async", null);

            return script;
        }
    }
}
