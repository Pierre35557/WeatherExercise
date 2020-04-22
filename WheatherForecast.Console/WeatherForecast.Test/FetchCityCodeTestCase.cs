using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using WeatherForcast.Domain;

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
            var countries = Convert_Countries_To_Object(jsonCountries);

            //Act
            var expected = 6951112;
            var actual = Fetch_Country_Code(countries, city, state, country);

            //Assert
            Assert.AreEqual(expected, actual);
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

        private string Get_Countries_From_Json_File()
        {
            return File.ReadAllText("External Files/city.list.json");
        }
    }
}