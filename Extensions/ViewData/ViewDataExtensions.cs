using System;
using System.Collections.Generic;

namespace XperienceCommunity.Locator
{
    public static class ViewDataExtensions
    {
        private const string KEY_NAME = "Locator_EditorAttributes";
        public static void AddEditorHtmlAttributes(this LocatorViewDataExtensionPoint helper,
            IDictionary<string, object> attributeDictionary)
            => helper.Instance.Add(KEY_NAME, attributeDictionary);

        public static IDictionary<string, object> GetEditorHtmlAttributes(this LocatorViewDataExtensionPoint helper)
            => helper.Instance.ContainsKey(KEY_NAME)
                ? helper.Instance[KEY_NAME] as IDictionary<string, object>
                : new Dictionary<string, object>(StringComparer.Ordinal);
    }
}
