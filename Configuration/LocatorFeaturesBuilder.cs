using System;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    internal class LocatorFeaturesBuilder : ILocatorFeatureBuilder
    {
        public Type BaseModelType { get; internal set; }
        public IServiceCollection Services { get; internal set; }

        public LocatorFeaturesBuilder(IServiceCollection appBuilder, Type baseModelType)
        {
            Services = appBuilder;
            BaseModelType = baseModelType;
        }
    }
}
