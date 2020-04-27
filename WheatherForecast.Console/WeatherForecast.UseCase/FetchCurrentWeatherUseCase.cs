using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Output;
using System;
using System.Threading.Tasks;
using WeatherForecast.Domain;
using WeatherForecast.Domain.Interfaces;
using WeatherForecast.Domain.UseCase.Interfaces;

namespace WeatherForecast.UseCase
{
    public class FetchCurrentWeatherUseCase : IWeatherUseCase
    {
        private readonly ICountry _country;
        private readonly IWeather _weather;

        public FetchCurrentWeatherUseCase(ICountry country,
                                          IWeather weather)
        {
            _country = country;
            _weather = weather;
        }

        public async Task Execute(Cities inputTo, IRespondWithSuccessOrError<CurrentWeather, ErrorOutput> presenter)
        {
            try
            {
                var city = await _country.Fetch_City_Code(inputTo.City, inputTo.State, inputTo.Country);
                var currentWeather = await _weather.Fetch_Weather_For_Today(city.CityId);

                presenter.Respond(currentWeather);
            }
            catch (Exception ex)
            {
                presenter.Respond(new ErrorOutput(ex.Message));
            }
        }
    }
}
