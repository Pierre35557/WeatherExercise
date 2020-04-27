using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Domain.Interfaces;

namespace WeatherForecast.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryUseCase _countryUseCase;

        public CountryController(ICountryUseCase countryUseCase)
        {
            _countryUseCase = countryUseCase;
        }


        [HttpGet(Name = "GetCountryCode")]
        public IActionResult GetCountryCode(string city, string country, string state)
        {
            return Ok();
        }
    }
}
