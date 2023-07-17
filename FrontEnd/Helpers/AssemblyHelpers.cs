using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace XperienceCommunity.Locator
{
    internal static class AssemblyHelpers
    {
        public static IEnumerable<TAttribute> GetAssemblyAttributes<TAttribute>(this IEnumerable<Assembly> assemblies)
        where TAttribute : Attribute
            => assemblies.SelectMany(s => s.GetCustomAttributes<TAttribute>());
    }
}
