using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Hosting;
using XperienceCommunity.Locator.Factories;
using XperienceCommunity.Locator.Interfaces;

namespace XperienceCommunity.Locator
{
    public static class ServiceCollectionExtensions
    {
        public static ILocationServiceCollection AddLocator(this IServiceCollection services, Action<ILocatorFeatureBuilder> builder = null)
        {
            return services.AddLocatorInternal<LocatorLocation>(builder);
        }

        public static ILocationServiceCollection AddLocator<TModel>(this IServiceCollection services, Action<ILocatorFeatureBuilder> builder = null)
            where TModel : LocatorLocation, new()
        {
            return services.AddLocatorInternal<TModel>(builder);
        }

        private static ILocationServiceCollection AddLocatorInternal<TModel>(this IServiceCollection services, Action<ILocatorFeatureBuilder> builder = null)
            where TModel : LocatorLocation, new()
        {
            var features = new LocatorFeaturesBuilder(services, typeof(TModel));
            builder?.Invoke(features);

            services.ConfigureOptions<LocatorOptions>();

            services.AddOptions<LocatorOptions>()
                .BindConfiguration(LocatorOptions.SECTION_NAME)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services
                .AddSingleton<IStartupFilter, RegisterAssemblyAttributesToStores>()
                .AddSingleton<ILocatorFilterComponentFactory, LocatorFilterComponentFactory>()
                .AddSingleton<ILocatorFilterPropertiesFactory, LocatorFilterPropertiesFactory>()
                .AddSingleton<ILocatorDefinitionStoreFactory, LocatorDefinitionStoreFactory>()
                .AddSingleton(typeof(ILocatorComponentDefinitionStore<>), typeof(LocatorComponentDefinitionStore<>))
                .AddSingleton(typeof(ILocatorComponentDefinitionProvider<>), typeof(LocatorComponentDefinitionProvider<>));

            return new LocatorServiceCollection(services);
        }
    }
}
