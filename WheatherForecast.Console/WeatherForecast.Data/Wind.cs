using Newtonsoft.Json;

namespace WeatherForecast.Data
{
    public class Wind
    {
        public float Speed { get; set; } 

        [JsonProperty("deg")]
        public int Degrees { get; set; }
    }
}
