namespace XperienceCommunity.Locator
{
    public abstract class LocatorFilterComponentProperties<TValue> : LocatorFilterComponentProperties
    {
        /// <summary>
        /// When overridden in a derived class, gets or sets the default value of the form component and underlying field.
        /// Use the <see cref="T:Kentico.Forms.Web.Mvc.DefaultValueEditingComponentAttribute" /> to specify a form component for editing.
        /// </summary>
        public abstract TValue DefaultValue { get; set; }


        /// <summary>
        /// Gets the default value. The <see cref="P:Kentico.Forms.Web.Mvc.FormComponentProperties`1.DefaultValue" /> property can be used
        /// directly to obtain the typed default value.
        /// </summary>
        /// <returns>Returns the default value.</returns>
        public override object GetDefaultValue() => (object)this.DefaultValue;

        /// <summary>
        /// Sets the default value to <paramref name="value" />.
        /// The <paramref name="value" /> must be of type <typeparamref name="TValue" /> or an exception is thrown.
        /// The <see cref="P:Kentico.Forms.Web.Mvc.FormComponentProperties`1.DefaultValue" /> property can be used directly to set the typed default value.
        /// </summary>
        /// <param name="value">Value to be set as the default value.</param>
        public override void SetDefaultValue(object value) => this.DefaultValue = (TValue)value;
    }

    public abstract class LocatorFilterComponentProperties
    {
        public virtual string Name { get; set; }
        public abstract string Label { get; set; }
        public abstract string HintText { get; set; }

        /// <summary>
        /// When overridden in a derived class, gets the default value.
        /// </summary>
        /// <returns>Returns the default value.</returns>
        public abstract object GetDefaultValue();

        /// <summary>
        /// When overridden in a derived class, sets the default value to <paramref name="value" />.
        /// The <paramref name="value" /> must be of proper type or an exception is thrown.
        /// </summary>
        /// <param name="value">Value to be set as the default value.</param>
        public abstract void SetDefaultValue(object value);
    }
}