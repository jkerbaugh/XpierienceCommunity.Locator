using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace XperienceCommunity.Locator
{
    public static class TagBuilderExtensions {

        public static void CombineAttributes(this TagBuilder tagBuilder, IDictionary<string, object> attributes)
        {
            foreach (var attribute in attributes)
            {
                var key = Convert.ToString(attribute.Key, CultureInfo.InvariantCulture);
                var value = Convert.ToString(attribute.Value, CultureInfo.InvariantCulture);
               
                CombineAttribute(tagBuilder, key, value);
            }
        }

        public static void CombineAttribute(this TagBuilder tagBuilder, string key, string value)
        {
            var attributes = tagBuilder.Attributes;
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (attributes.TryGetValue(key, out var existingValue))
            {
                attributes[key] = $"{existingValue} {value}";
            }
            else
            {
                attributes.Add(key, value);
            }
        }
    }
}
