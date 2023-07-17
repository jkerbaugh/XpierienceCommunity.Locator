using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    internal class LocatorServiceCollection : ILocationServiceCollection
    {
        public LocatorServiceCollection(IServiceCollection services) => Services = services;

        public IServiceCollection Services { get; }
    }
}
