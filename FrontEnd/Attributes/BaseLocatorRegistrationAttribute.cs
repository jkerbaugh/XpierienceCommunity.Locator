using System;

namespace XperienceCommunity.Locator
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public abstract class BaseLocatorRegistrationAttribute : Attribute
    {
        protected BaseLocatorRegistrationAttribute(string identifier, Type filterComponentType, string name)
        {
            Identifier = identifier;
            MarkedType = filterComponentType;
            Name = name;
        }

        public string Identifier { get; protected set; }
        public string Name { get; protected set; }
        public Type MarkedType { get; protected set; }

        internal abstract BaseLocatorDefinition CreateDefinition();
    }
}
