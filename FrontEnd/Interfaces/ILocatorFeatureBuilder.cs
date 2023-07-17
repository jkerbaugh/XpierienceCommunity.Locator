using System;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    public interface ILocatorFeatureBuilder
    {
        public Type BaseModelType { get; }
        public IServiceCollection Services { get; }
    }
}
