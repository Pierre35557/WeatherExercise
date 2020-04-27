using Newtonsoft.Json;

namespace WeatherForecast.Data
{
    public class Main
    {
        public float Temp { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }

        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public float MinTemprature { get; set; }

        [JsonProperty("temp_max")]
        public float MaxTemprature { get; set; }
    }
}
