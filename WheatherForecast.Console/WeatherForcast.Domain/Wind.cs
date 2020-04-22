using Newtonsoft.Json;

namespace WeatherForcast.Domain
{
    public class Wind
    {
        public float Speed { get; set; } 

        //Think it's degrees?
        [JsonProperty("deg")]
        public int Degrees { get; set; }
    }
}
