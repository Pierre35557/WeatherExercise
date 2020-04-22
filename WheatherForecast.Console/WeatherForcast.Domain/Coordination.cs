using Newtonsoft.Json;

namespace WeatherForcast.Domain
{
    public class Coordination
    {
        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("lat")]
        public float Latitude { get; set; }
    }
}
