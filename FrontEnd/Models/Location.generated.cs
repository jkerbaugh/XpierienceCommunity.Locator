using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;

using CMS;
using CMS.DataEngine;
using CMS.Helpers;
using LocationManagement;

[assembly: RegisterObjectType(typeof(LocationInfo), LocationInfo.OBJECT_TYPE)]

namespace LocationManagement
{
    /// <summary>
    /// Data container class for <see cref="LocationInfo"/>.
    /// </summary>
    [Serializable]
    public partial class LocationInfo : AbstractInfo<LocationInfo, ILocationInfoProvider>
    {
        /// <summary>
        /// Object type.
        /// </summary>
        public const string OBJECT_TYPE = "locationmanagement.location";


        /// <summary>
        /// Type information.
        /// </summary>
        #warning "You will need to configure the type info."
        public static readonly ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(LocationInfoProvider), OBJECT_TYPE, "LocationManagement.Location", "LocationID", "LocationLastModified", "LocationGuid", "LocationCodename", "LocationName", null, "LocationSiteID", null, null)
        {
            ModuleName = "LocationManagement",
            TouchCacheDependencies = true,
            DependsOn = new List<ObjectDependency>()
            {
                new ObjectDependency("LocationSiteID", "cms.site", ObjectDependencyEnum.Binding),
            },
        };


        /// <summary>
        /// Location ID.
        /// </summary>
        [DatabaseField]
        public virtual int LocationID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("LocationID"), 0);
            }
            set
            {
                SetValue("LocationID", value);
            }
        }


        /// <summary>
        /// Location guid.
        /// </summary>
        [DatabaseField]
        public virtual Guid LocationGuid
        {
            get
            {
                return ValidationHelper.GetGuid(GetValue("LocationGuid"), Guid.Empty);
            }
            set
            {
                SetValue("LocationGuid", value);
            }
        }


        /// <summary>
        /// Location site ID.
        /// </summary>
        [DatabaseField]
        public virtual int LocationSiteID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("LocationSiteID"), 0);
            }
            set
            {
                SetValue("LocationSiteID", value);
            }
        }


        /// <summary>
        /// Location last modified.
        /// </summary>
        [DatabaseField]
        public virtual DateTime LocationLastModified
        {
            get
            {
                return ValidationHelper.GetDateTime(GetValue("LocationLastModified"), DateTimeHelper.ZERO_TIME);
            }
            set
            {
                SetValue("LocationLastModified", value);
            }
        }


        /// <summary>
        /// Location distance.
        /// </summary>
        [DatabaseField]
        public virtual double LocationDistance
        {
            get
            {
                return ValidationHelper.GetDouble(GetValue("LocationDistance"), 0d);
            }
            set
            {
                SetValue("LocationDistance", value, 0d);
            }
        }


        /// <summary>
        /// Location name.
        /// </summary>
        [DatabaseField]
        public virtual string LocationName
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LocationName"), String.Empty);
            }
            set
            {
                SetValue("LocationName", value);
            }
        }


        /// <summary>
        /// Location codename.
        /// </summary>
        [DatabaseField]
        public virtual string LocationCodename
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LocationCodename"), String.Empty);
            }
            set
            {
                SetValue("LocationCodename", value);
            }
        }


        /// <summary>
        /// Location type.
        /// </summary>
        [DatabaseField]
        public virtual string LocationType
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LocationType"), String.Empty);
            }
            set
            {
                SetValue("LocationType", value);
            }
        }


        /// <summary>
        /// Location phone number.
        /// </summary>
        [DatabaseField]
        public virtual string LocationPhoneNumber
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LocationPhoneNumber"), String.Empty);
            }
            set
            {
                SetValue("LocationPhoneNumber", value);
            }
        }


        /// <summary>
        /// Location formatted address.
        /// </summary>
        [DatabaseField]
        public virtual string LocationFormattedAddress
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LocationFormattedAddress"), String.Empty);
            }
            set
            {
                SetValue("LocationFormattedAddress", value);
            }
        }


        /// <summary>
        /// Location latitude.
        /// </summary>
        [DatabaseField]
        public virtual double LocationLatitude
        {
            get
            {
                return ValidationHelper.GetDouble(GetValue("LocationLatitude"), 0d);
            }
            set
            {
                SetValue("LocationLatitude", value);
            }
        }


        /// <summary>
        /// Location longitude.
        /// </summary>
        [DatabaseField]
        public virtual double LocationLongitude
        {
            get
            {
                return ValidationHelper.GetDouble(GetValue("LocationLongitude"), 0d);
            }
            set
            {
                SetValue("LocationLongitude", value);
            }
        }


        /// <summary>
        /// Location static map.
        /// </summary>
        [DatabaseField]
        public virtual string LocationStaticMap
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LocationStaticMap"), String.Empty);
            }
            set
            {
                SetValue("LocationStaticMap", value, String.Empty);
            }
        }


        /// <summary>
        /// Location alert message.
        /// </summary>
        [DatabaseField]
        public virtual string LocationAlertMessage
        {
            get
            {
                return ValidationHelper.GetString(GetValue("LocationAlertMessage"), String.Empty);
            }
            set
            {
                SetValue("LocationAlertMessage", value, String.Empty);
            }
        }


        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            Provider.Delete(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            Provider.Set(this);
        }


        /// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected LocationInfo(SerializationInfo info, StreamingContext context)
            : base(info, context, TYPEINFO)
        {
        }


        /// <summary>
        /// Creates an empty instance of the <see cref="LocationInfo"/> class.
        /// </summary>
        public LocationInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Creates a new instances of the <see cref="LocationInfo"/> class from the given <see cref="DataRow"/>.
        /// </summary>
        /// <param name="dr">DataRow with the object data.</param>
        public LocationInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }
    }
}