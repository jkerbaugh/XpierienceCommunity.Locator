using Kentico.Forms.Web.Mvc;
using System;
using CMS.DataEngine.Internal;

namespace XperienceCommunity.Locator
{
    public class LocatorFilterComponentDefinition : BaseLocatorDefinition
    {
        public Type FilterComponentType { get; }

        public Type FilterComponentPropertiesType { get; }

        public Type FilterRenderingConfigurationType { get; }

        public Type ValueType { get; }

        public string ViewName { get; set; }

        public LocatorFilterComponentDefinition(string identifier, Type filterComponentType, Type filterRenderingConfigurationType, string name) 
            : base(identifier, name)
        {
            ValidateTypes(filterComponentType);

            FilterComponentType = filterComponentType;
            FilterRenderingConfigurationType = filterRenderingConfigurationType;
            FilterComponentPropertiesType = GetPropertiesType(filterComponentType);
            ValueType = GetValueType(filterComponentType);
        }

        private void ValidateTypes(Type filterComponentType)
        {
            if (filterComponentType == null)
                throw new ArgumentNullException(nameof(filterComponentType), "The form component type must be specified.");
            
            if (filterComponentType.FindTypeByGenericDefinition(typeof(LocatorFilterComponent<,>)) == null)
                throw new ArgumentException("Implementation of the '" + filterComponentType.FullName + "' form component must inherit the '" + typeof(LocatorFilterComponent<,>).FullName + "' class.");
            
            if (filterComponentType.IsAbstract)
                throw new ArgumentException("Implementation of the '" + filterComponentType.FullName + "' form component type cannot be abstract.", nameof(filterComponentType));
            
            if (filterComponentType.IsGenericType && !filterComponentType.IsConstructedGenericType)
                throw new ArgumentException("Implementation of the '" + filterComponentType.FullName + "' form component must be a constructed generic type.", nameof(filterComponentType));
        }

        private Type GetPropertiesType(Type formComponentType) => formComponentType.FindTypeByGenericDefinition(typeof(LocatorFilterComponent<,>)).GetGenericArguments()[0];

        private Type GetValueType(Type formComponentType) => formComponentType.FindTypeByGenericDefinition(typeof(LocatorFilterComponent<,>)).GetGenericArguments()[1];
    }
}
