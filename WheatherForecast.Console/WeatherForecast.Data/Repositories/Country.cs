using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Domain;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecast.Data.Repositories
{
    public class Country : ICountry
    {
        public static Cities nullTemplate = null;

        public async Task<Cities> Fetch_City_Code(string city, string state, string country)
        {
            var jsonCountries = await Get_Countries_From_Json_File();
            var countries = Deserialize_Countries(jsonCountries);

            //Todo: How do I handle exceptions? Should I have a try / catch
            //And return the nullTemplate in the catch?
            return Fetch_Country_Code(countries, city, state, country);
        }

        private List<Domain.Country> Deserialize_Countries(string jsonCountries)
        {
            var country = new Data.Country();

            return country.Deserialize_Countries(jsonCountries);
        }

        private Cities Fetch_Country_Code(List<Domain.Country> countries, string city, string state, string country)
        {
            var cityId = countries.FirstOrDefault(c => c.State == state && c.Name == city && c.CountryCode == country).Id;

            return new Cities
            {
                City = city,
                State = state,
                CityId = cityId,
                Country = country,
            };
        }

        private async Task<string> Get_Countries_From_Json_File()
        {
            return await File.ReadAllTextAsync("External Files/city.list.json");
        }
    }
}
