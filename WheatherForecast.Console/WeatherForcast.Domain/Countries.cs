using Newtonsoft.Json;

namespace WeatherForcast.Domain
{
    //Change the naming of the class. Should be singular
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [JsonProperty("coord")]
        public Coordination Coordination { get; set; }
    }
}
