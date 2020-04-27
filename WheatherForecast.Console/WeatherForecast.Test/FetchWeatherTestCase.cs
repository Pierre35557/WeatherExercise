using AutoMapper;
using NUnit.Framework;
using System;
using System.Net.Http;
using WeatherForecast.Domain;

namespace WeatherForecast.Test
{
    [TestFixture]
    public class FetchWeatherTestCase
    {
        public static CurrentWeather nullTemplate = null;
        private readonly string ApiKey = "6e1c13a3fa3a14a2528e366cc78f415f";

        [Test]
        public async void Fetch_Weather_For_Today()
        {
            var _country = new Data.Repositories.Country();
            
            //Arrange
            var city = await _country.Fetch_City_Code("Somerset West", "", "ZA");
            var client = Create_Http_Client(city);

            //Act
            var currentWeather = Fetch_Current_Weather(client);

            //Assert
            Assert.True(currentWeather != null);
        }

        private HttpClient Create_Http_Client(Cities city)
        {
            return new HttpClient() { BaseAddress = new Uri($"http://api.openweathermap.org/data/2.5/weather?id={city.CityId}&appid={ApiKey}") };
        }

        private CurrentWeather Fetch_Current_Weather(HttpClient client)
        {
            var mapper = Create_Mapper();
            var result = client.GetAsync(client.BaseAddress).Result;

            if (!result.IsSuccessStatusCode)
                return nullTemplate;

            var weather = result.Content.ReadAsAsync<Data.CurrentWeather>().Result;
            var entity = mapper.Map<CurrentWeather>(weather);

            return entity;
        }

        private IMapper Create_Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.CurrentWeather, CurrentWeather>();
            });

            return config.CreateMapper();
        }
    }
}
