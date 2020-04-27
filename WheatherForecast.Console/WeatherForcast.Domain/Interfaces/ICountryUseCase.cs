using StoneAge.CleanArchitecture.Domain;
using WeatherForecast.Domain.UseCase;

namespace WeatherForecast.Domain.Interfaces
{
    public interface ICountryUseCase : IUseCaseAsync<Cities, Cities>
    {
    }
}
