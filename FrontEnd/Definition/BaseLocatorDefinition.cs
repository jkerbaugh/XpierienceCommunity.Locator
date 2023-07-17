using System;
using CMS.Helpers;

namespace XperienceCommunity.Locator
{
    public class BaseLocatorDefinition
    {
        public string Identifier { get; set; }

        public string Name { get; set; }

        public BaseLocatorDefinition(string identifier, string name)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentException("The locator component componentDefinition identifier cannot be empty.", nameof(identifier));
            if (!ValidationHelper.IsCodeName(identifier))
                throw new ArgumentException("The locator component componentDefinition identifier contains invalid character.", nameof(identifier));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The locator component name cannot be empty.", nameof(name));

            Identifier = identifier;
            Name = name;
        }
    }
}
