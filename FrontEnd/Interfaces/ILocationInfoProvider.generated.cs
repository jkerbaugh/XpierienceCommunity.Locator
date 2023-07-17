using CMS.DataEngine;

namespace LocationManagement
{
    /// <summary>
    /// Declares members for <see cref="LocationInfo"/> management.
    /// </summary>
    public partial interface ILocationInfoProvider : IInfoProvider<LocationInfo>, IInfoByIdProvider<LocationInfo>, IInfoBySiteAndNameProvider<LocationInfo>
    {
    }
}