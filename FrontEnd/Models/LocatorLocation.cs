using LocationManagement;

namespace XperienceCommunity.Locator
{
    public class LocatorLocation
    {
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Distance { get; set; }

        public virtual void MapFromInfoObject(LocationInfo location)
        {
            this.Name = location.LocationName;
            this.Longitude = location.LocationLongitude;
            this.Latitude = location.LocationLatitude;
        }
    }
}
