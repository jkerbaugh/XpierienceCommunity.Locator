using System;

namespace XperienceCommunity.Locator
{
    internal static class ControllerHelpers
    {
        public static string RemoveControllerPrefix(this string controller)
        {
            return controller.IndexOf(nameof(controller), StringComparison.InvariantCultureIgnoreCase) >= 0
                ? controller[..nameof(controller).Length]
                : controller;
        }
    }
}
