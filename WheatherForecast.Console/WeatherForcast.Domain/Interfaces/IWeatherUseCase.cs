using StoneAge.CleanArchitecture.Domain;

namespace WeatherForecast.Domain.UseCase.Interfaces
{
    public interface IWeatherUseCase : IUseCaseAsync<Cities, CurrentWeather>
    {
    }
}