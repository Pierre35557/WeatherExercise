using Newtonsoft.Json;

namespace WeatherForecast.Data
{
    public class Coordination
    {
        [JsonProperty("lon")]
        public float Longitude { get; set; }

        [JsonProperty("lat")]
        public float Latitude { get; set; }
    }
}
