using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WeatherForecast.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        [JsonProperty("country")]
        public string CountryCode { get; set; }

        [JsonProperty("coord")]
        public Coordination Coordination { get; set; }

        public List<Domain.Country> Deserialize_Countries(string jsonCountries)
        {
            var result = JsonConvert.DeserializeObject<List<Country>>(jsonCountries);

            return result.Select(c => new Domain.Country
            {
                Id = c.Id,
                Name = c.Name,
                State = c.State,
                CountryCode = c.CountryCode,

                Coordination = new Domain.Coordination
                {
                    Latitude = c.Coordination.Latitude,
                    Longitude = c.Coordination.Longitude
                }
            }).ToList();
        }
    }
}
