using System;
using System.Collections.Generic;
using System.Text;

namespace XperienceCommunity.Locator.Models
{
    internal static class DefaultFormRenderingConfiguration
    {

        public static IDictionary<string, object> WrapperHtmlAttributes => new Dictionary<string, object>()
        {
            {"class", "locator-editor-wrapper"}
        };

        public static IDictionary<string, object> LabelHtmlAttributes => new Dictionary<string, object>
        {
            {"class", "form-label"}
        };

        public static IDictionary<string, object> EditorHtmlAttributes => new Dictionary<string, object>{
            {"class", "form-control"}
        };
    }
}
