using AutoMapper;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeatherForecast.Domain;

namespace WeatherForecast.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FetchWeather_WhenGivenCityStateAndCountryCode_ShouldReturnCountryCode()
        {
            //Arrange
            string city = "Somerset West";
            string state = "";
            string country = "ZA";

            var jsonCountries = Get_Countries_From_Json_File();
            var countries = Deserialize_Countries(jsonCountries);

            //Act
            var expected = 6951112;
            var actual = Fetch_Country_Code(countries, city, state, country);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private List<Country> Deserialize_Countries(string jsonCountries)
        {
            var mapper = Create_Mapper();
            var country = new Data.Country();

            var result = country.Deserialize_Countries(jsonCountries);

            //Should we add the mapper on the data class?
            var entity = mapper.Map<List<Country>>(result);

            return entity;
        }

        private int Fetch_Country_Code(List<Country> countries, string city, string state, string country)
        {
            return countries.FirstOrDefault(c => c.State == state && c.Name == city && c.CountryCode == country).Id;
        }

        private string Get_Countries_From_Json_File()
        {
            return File.ReadAllText("External Files/city.list.json");
        }

        private IMapper Create_Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Country, Country>();
            });

            return config.CreateMapper();
        }
    }
}