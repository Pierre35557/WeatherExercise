using System.Threading.Tasks;

namespace WeatherForecast.Domain.Interfaces
{
    public interface IWeather
    {
        Task<CurrentWeather> Fetch_Weather_For_Today(int cityId);
    }
}
