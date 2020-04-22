using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForcast.Domain
{
    public class CurrentWeather
    {
        public string Base {get;set;}
        public long Visibility { get; set; }

        public Wind Wind { get; set; }

        [JsonProperty("coord")]
        public Coordination Coordination { get; set; }

        public List<Weather> Weather { get; set; }
    }
}