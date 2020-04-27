using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Output;
using System;
using System.Threading.Tasks;
using WeatherForecast.Domain;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecase.UseCase
{
    public class FetchCountryCodeUseCase : ICountryUseCase
    {
        private readonly ICountry _country;

        public FetchCountryCodeUseCase(ICountry country)
        {
            _country = country;
        }

        public async Task Execute(Cities inputTo, IRespondWithSuccessOrError<Cities, ErrorOutput> presenter)
        {
            try
            {
                var city = await _country.Fetch_City_Code(inputTo.City, inputTo.State, inputTo.Country);
                presenter.Respond(city);
            }
            catch (Exception ex)
            {
                presenter.Respond(new ErrorOutput(ex.Message));
            }
        }
    }
}
