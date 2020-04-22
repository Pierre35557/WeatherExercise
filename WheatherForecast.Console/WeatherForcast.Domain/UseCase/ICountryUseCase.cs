using System;
using StoneAge.CleanArchitecture.Domain;
using WeatherForcast.Domain.UseCase;

namespace WeatherForcast.Domain
{
    public interface ICountryUseCase : IUseCaseAsync<Cities, int>
    {
    }
}
