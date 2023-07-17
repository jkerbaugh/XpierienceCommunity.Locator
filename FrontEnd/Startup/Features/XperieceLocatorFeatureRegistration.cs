using System;
using Microsoft.Extensions.DependencyInjection;
using XperienceCommunity.Locator.Interfaces;
using XperienceCommunity.Locator.Providers;

namespace XperienceCommunity.Locator.Startup.Features
{
    public static class XperieceLocatorFeatureRegistration
    {
        public static ILocatorFeatureBuilder AddXperience(this ILocatorFeatureBuilder builder)
        {
            var services = builder.Services;

            var interfaceType = typeof(ILocatorDataProvider<>).MakeGenericType(builder.BaseModelType);
            var concreteType = typeof(XperienceLocationProvider<>).MakeGenericType(builder.BaseModelType);

            services.AddTransient(interfaceType, concreteType);

            return builder;
        }
    }
}
