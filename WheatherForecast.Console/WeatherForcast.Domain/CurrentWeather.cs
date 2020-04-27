using System.Collections.Generic;

namespace WeatherForecast.Domain
{
    public class CurrentWeather
    {
        public string Base {get;set;}
        public long Visibility { get; set; }

        public Wind Wind { get; set; }

        public Coordination Coordination { get; set; }

        public IEnumerable<Weather> Weather { get; set; }
    }
}