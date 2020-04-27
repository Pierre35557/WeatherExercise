using Microsoft.AspNetCore.Mvc;
using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Domain;
using WeatherForecast.Domain.Interfaces;
using WeatherForecast.Domain.UseCase.Interfaces;

namespace WeatherForecast.Web.Controllers
{
    // todo : avoid naming folders technically, e.g Controllers, instead use WeatherForcast as a name
    // always try to find names that aline to the business domain. It quite obvious that controllers live in web project
    // I worry more about that purpose they are filling.
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherUseCase _weather;

        public WeatherController(IWeatherUseCase weather,
                                 ICountryUseCase country)
        {
            _weather = weather;
        }

        [HttpGet(Name = "WeatherForecast")]
        public async Task<IActionResult> Weather_Forecast(string country, string state, string city)
        {
            var weather = await Fetch_Current_Weather(Build_City_Model(country, state, city));

            return Ok(weather.Weather);
        }

        private async Task<CurrentWeather> Fetch_Current_Weather(Cities city)
        {
            var weatherPresenter = new PropertyPresenter<CurrentWeather, ErrorOutput>();

            await _weather.Execute(city, weatherPresenter);

            return weatherPresenter.SuccessContent;
        }

        private Cities Build_City_Model(string country, string state, string city)
        {
            return new Cities
            {
                City = city,
                State = state,
                Country = country
            };
        }
    }
}
