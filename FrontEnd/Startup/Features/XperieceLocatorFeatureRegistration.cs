using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using XperienceCommunity.Locator.Interfaces;
using XperienceCommunity.Locator.Providers;

namespace XperienceCommunity.Locator.Startup.Features
{
    public static class XperieceLocatorFeatureRegistration
    {
        public static ILocatorFeatureBuilder AddXperience(this ILocatorFeatureBuilder builder)
        {
            return AddDataProviderInternal(builder, typeof(XperienceLocationProvider<>));

        }

        public static ILocatorFeatureBuilder AddDataProvider(this ILocatorFeatureBuilder builder, Type type)
        {
            return AddDataProviderInternal(builder, type);
        }

        internal static ILocatorFeatureBuilder AddDataProviderInternal(this ILocatorFeatureBuilder builder, Type type)
        {
            var interfaceType = typeof(ILocatorDataProvider<>).MakeGenericType(builder.BaseModelType);
            
            if (!type.GetInterfaces().Any(x =>
                    x.IsGenericType &&
                    x.GetGenericTypeDefinition() == typeof(ILocatorDataProvider<>)))
                throw new ArgumentException($"{type.FullName} must inherit {typeof(ILocatorDataProvider<>).FullName}");

            var services = builder.Services;

            var concreteType = type.MakeGenericType(builder.BaseModelType);

            services.AddTransient(interfaceType, concreteType);

            return builder;
        }
    }
}
