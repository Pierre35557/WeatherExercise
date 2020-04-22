using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Output;
using System.Threading.Tasks;
using WeatherForcast.Domain;
using WeatherForcast.Domain.UseCase;

namespace WeatherForecase.UseCase
{
    public class FetchCountryCodeUseCase : ICountryUseCase
    {
        private readonly ICountry _country;

        public FetchCountryCodeUseCase(ICountry country)
        {
            _country = country;
        }

        public async Task Execute(Cities inputTo, IRespondWithSuccessOrError<int, ErrorOutput> presenter)
        {
            //Todo: Is this correct?
            //Todo: Is there a different way of doing this?
            var cityCode = await _country.Fetch_City_Code(inputTo.City, inputTo.State, inputTo.Country);
            presenter.Respond(cityCode);
        }
    }
}
