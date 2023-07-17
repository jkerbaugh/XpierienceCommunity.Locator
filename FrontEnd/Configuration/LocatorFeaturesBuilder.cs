using System;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    internal class LocatorFeaturesBuilder : ILocatorFeatureBuilder
    {
        public Type BaseModelType { get; }
        public IServiceCollection Services { get; }

        public LocatorFeaturesBuilder(IServiceCollection appBuilder, Type baseModelType)
        {
            Services = appBuilder;
            BaseModelType = baseModelType;
        }
    }
}
