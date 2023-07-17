using System;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.Locator
{
    internal static class ActivatorHelper
    {
        public static TType ActivateInternal<TType>(this IServiceProvider provider, Type instanceType)
        {
            return ActivatorUtilities.CreateInstance<TType>(provider, instanceType);
        }
    }
}
