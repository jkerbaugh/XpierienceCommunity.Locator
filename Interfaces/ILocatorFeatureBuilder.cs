using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    public interface ILocatorFeatureBuilder
    {
        public IServiceCollection Services { get; }
    }
}
