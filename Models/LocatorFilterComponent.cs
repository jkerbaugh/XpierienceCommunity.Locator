using System;
using System.Collections.Generic;
using System.Linq;
using Kentico.Forms.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using XperienceCommunity.Locator.Models;

namespace XperienceCommunity.Locator
{
    public abstract class LocatorFilterComponent : LocatorBaseComponent
    {
        /// <summary>
        /// Sets the order the filter component is displayed in the interface
        /// </summary>
        public abstract int Order { get; }

        protected LocatorFilterComponent(Type propertiesType)
        {
            PropertiesType = propertiesType;
        }

        internal LocatorFilterComponentDefinition ComponentDefinition { get; set; }

        internal LocatorControlRenderingConfiguration RenderingConfiguration { get; set; }

        internal Type PropertiesType { get; }

        internal abstract LocatorFilterComponentProperties BaseProperties { get; }

        public virtual string LabelForPropertyName => GetType().GetProperties()
            .FirstOrDefault((p => p.GetCustomAttributes(typeof(BindPropertyAttribute), false).Length != 0))?.Name;


        public abstract void LoadProperties(LocatorFilterComponentProperties properties);

        internal abstract object GetValueInternal();

        internal abstract void SetValueInternal(object value);

        //internal abstract FilterMetadata ToMetadataInternal();
    }

    public abstract class LocatorFilterComponent<TProperties, TValue> : LocatorFilterComponent
        where TProperties : LocatorFilterComponentProperties
    {
        public override int Order { get; } = 0;

        public abstract TValue Value { get; set; }

        protected LocatorFilterComponent()
            : base(typeof(TProperties))
        {
        }

        public TProperties Properties { get; protected set; }

        internal override LocatorFilterComponentProperties BaseProperties => Properties;

        public override void LoadProperties(LocatorFilterComponentProperties properties)
        {
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            Properties = properties is TProperties properties1
                ? properties1
                : throw new ArgumentException("Properties for the '" + GetType().FullName +
                                              "' form component must be of type '" + PropertiesType.FullName +
                                              "'. Given instance of properties of type '" +
                                              properties.GetType().FullName + "' cannot be used.");
        }

        public abstract TValue GetValue();

        public abstract void SetValue(TValue value);

        internal override object GetValueInternal() => GetValue();

        internal override void SetValueInternal(object value) => SetValue((TValue)value);

    }
}
