using AutoMapper;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecast.Data.Repositories
{
    public class Weather : IWeather
    {
        public static Domain.CurrentWeather nullTemplate = null;

        //Add to settings
        private readonly string ApiKey = "6e1c13a3fa3a14a2528e366cc78f415f";

        public async Task<Domain.CurrentWeather> Fetch_Weather_For_Today(int cityId)
        {
            var client = Create_Http_Client(cityId);

            var currentWeather = await Fetch_Current_Weather(client);

            return currentWeather;
        }

        private HttpClient Create_Http_Client(int cityId)
        {
            return new HttpClient() { BaseAddress = new Uri($"http://api.openweathermap.org/data/2.5/weather?id={cityId}&appid={ApiKey}") };
        }

        private async Task<Domain.CurrentWeather> Fetch_Current_Weather(HttpClient client)
        {
            var mapper = Create_Mapper();
            var result = await client.GetAsync(client.BaseAddress);

            if (!result.IsSuccessStatusCode)
                return nullTemplate;

            var weather = await result.Content.ReadAsAsync<CurrentWeather>();

            return new Domain.CurrentWeather
            {
                Base = weather.Base,
                Visibility = weather.Visibility,
                Coordination = new Domain.Coordination
                {
                    Latitude = weather.Coordination.Latitude,
                    Longitude = weather.Coordination.Longitude
                },
                Weather = weather.Weather.Select(w => new Domain.Weather
                {
                    Id = w.Id,
                    Icon = w.Icon,
                    Main = w.Main,
                    Description = w.Description
                }),
                Wind = new Domain.Wind
                {
                    Speed = weather.Wind.Speed,
                    Degrees = weather.Wind.Degrees
                }
            };
            //This line breaks, is it due to nested classes?
            //var entity = mapper.Map<Domain.CurrentWeather>(weather);

            //return entity;
        }

        private IMapper Create_Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CurrentWeather, Domain.CurrentWeather>();
            });

            return config.CreateMapper();
        }
    }
}
