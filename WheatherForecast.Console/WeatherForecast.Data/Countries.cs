using Newtonsoft.Json;
using System;

namespace WeatherForecast.Data
{
    // todo : Make the entity singular and the repository plural 
    // E.g this becomes Country and Countries would be the repository / gateway that deals with the DB or API
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Coordination Coordination { get; set; }
    }
}
