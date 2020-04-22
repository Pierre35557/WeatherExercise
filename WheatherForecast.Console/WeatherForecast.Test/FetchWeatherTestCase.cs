using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForcast.Domain;
using WeatherForecast.Data;

namespace WeatherForecast.Test
{
    [TestFixture]
    public class FetchWeatherTestCase
    {
        private readonly string ApiKey = "6e1c13a3fa3a14a2528e366cc78f415f";

        [Test]
        public async void Fetch_Weather_For_Today()
        {
            var _country = new Country();
            
            //Arrange
            int cityCode = await _country.Fetch_City_Code("Somerset West", "", "ZA");
            var client = Create_Http_Client(cityCode);

            //Act
            var currentWeather = Fetch_Current_Weather(client);

            //Assert
            //How do I test the result?
        }

        private HttpClient Create_Http_Client(int cityId)
        {
            return new HttpClient() { BaseAddress = new Uri($"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={ApiKey}") };
        }

        private CurrentWeather Fetch_Current_Weather(HttpClient client)
        {
            var result = client.GetAsync(client.BaseAddress).Result;

            //Should I follow the null object pattern?
            if (!result.IsSuccessStatusCode)
                throw new Exception();

            var currentWeather = result.Content.ReadAsAsync<CurrentWeather>().Result;

            return currentWeather;
        }
    }
}
