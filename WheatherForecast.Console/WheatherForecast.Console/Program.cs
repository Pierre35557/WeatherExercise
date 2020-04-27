using StoneAge.CleanArchitecture.Domain.Messages;
using StoneAge.CleanArchitecture.Domain.Presenters;
using System.Threading.Tasks;
using WeatherForecast.Domain;
using WeatherForecast.Domain.Interfaces;
using WeatherForecast.Domain.UseCase.Interfaces;
using WeatherForecast.UseCase;
using Repository = WeatherForecast.Data.Repositories;

namespace WheatherForecast.Console
{
    class Program
    {
        private static readonly ICountry _country = new Repository.Country();
        private static readonly IWeather _weather = new Repository.Weather();
        private static readonly PropertyPresenter<CurrentWeather, ErrorOutput> weatherPresenter = new PropertyPresenter<CurrentWeather, ErrorOutput>();

        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Please enter your country, state and city as comma seperated text. If state is empty, add a space proceeded by a comma");

            var lineResult = System.Console.ReadLine();
            var splitResult = lineResult.Split(',');

            var city = new Cities { State = splitResult[1].Trim(), City = splitResult[2].Trim(), Country = splitResult[0].Trim() };

            var weather = await Fetch_Current_Weather(city);

            Write_Weather_To_Console(weather);
        }

        public static async Task<CurrentWeather> Fetch_Current_Weather(Cities city)
        {
            IWeatherUseCase _weatherUseCase = new FetchCurrentWeatherUseCase(_country, _weather);
            await _weatherUseCase.Execute(city, weatherPresenter);

            return weatherPresenter.SuccessContent;
        }

        private static void Write_Weather_To_Console(CurrentWeather weather)
        {
            foreach (var item in weather.Weather)
            {
                System.Console.WriteLine($"Weather Information: {item.Main}\n{item.Description}");
            }
        }
    }
}
