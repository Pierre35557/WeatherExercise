using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeatherForcast.Domain;

namespace WeatherForecast.Data
{
    public class Country : ICountry
    {
        public async Task<int> Fetch_City_Code(string city, string state, string country)
        {
            var jsonCountries = await Get_Countries_From_Json_File();
            var countries = Convert_Countries_To_Object(jsonCountries);

            return Fetch_Country_Code(countries, city, state, country);
        }

        //Change naming
        private List<Countries> Convert_Countries_To_Object(string jsonCountries)
        {
            return JsonConvert.DeserializeObject<List<Countries>>(jsonCountries);
        }

        private int Fetch_Country_Code(List<Countries> countries, string city, string state, string country)
        {
            return countries.FirstOrDefault(c => c.State == state && c.Name == city && c.Country == country).Id;
        }

        private async Task<string> Get_Countries_From_Json_File()
        {
            return await File.ReadAllTextAsync("External Files/city.list.json");
        }
    }
}
