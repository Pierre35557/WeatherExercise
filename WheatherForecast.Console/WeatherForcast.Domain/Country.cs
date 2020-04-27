using Newtonsoft.Json;

namespace WeatherForecast.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }

        public Coordination Coordination { get; set; }
    }
}
