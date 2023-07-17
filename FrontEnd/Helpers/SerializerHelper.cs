using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace XperienceCommunity.Locator
{
    internal class SerializerHelper
    {
        public static JsonSerializerSettings GetDefaultSerializerSettings()
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Include,
                Culture = Thread.CurrentThread.CurrentCulture
            };

            settings.Converters.Add(new StringEnumConverter());

            return settings;
        }
    }
}
