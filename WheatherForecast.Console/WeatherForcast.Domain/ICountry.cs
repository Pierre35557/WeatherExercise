using System;
using System.Threading.Tasks;

namespace WeatherForcast.Domain
{
    public interface ICountry
    {
        Task<int> Fetch_City_Code(string city, string state, string country);
    }
}
