using System.Threading.Tasks;

namespace WeatherForecast.Domain.Interfaces
{
    public interface ICountry
    {
        Task<Cities> Fetch_City_Code(string city, string state, string country);
    }
}
