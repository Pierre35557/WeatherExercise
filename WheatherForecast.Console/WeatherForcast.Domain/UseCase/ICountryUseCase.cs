using System;
using StoneAge.CleanArchitecture.Domain;
using WeatherForcast.Domain.UseCase;

namespace WeatherForcast.Domain
{
    // todo : it is often best to model privatives onto an object
    // this way as the needs of the usecase change you just add properties without changing the type
    // change int to City with an Id property of int
    public interface ICountryUseCase : IUseCaseAsync<Cities, int>
    {
    }
}
