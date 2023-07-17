using System.Collections.Generic;

namespace XperienceCommunity.Locator
{
    public class LocatorControlRenderingConfiguration
    {
        public virtual string WrapperElement => "div";

        public virtual IDictionary<string, object> WrapperHtmlAttributes => DefaultFormRenderingConfiguration.WrapperHtmlAttributes;
        public virtual IDictionary<string, object> LabelHtmlAttributes => DefaultFormRenderingConfiguration.LabelHtmlAttributes;
        public virtual IDictionary<string, object> EditorHtmlAttributes => DefaultFormRenderingConfiguration.EditorHtmlAttributes;

    }
}
