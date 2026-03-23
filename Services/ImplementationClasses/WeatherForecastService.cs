using RepositoryDesignPattern.Services.Interfaces;

namespace RepositoryDesignPattern.Services.ImplementationClasses
{
    public class WeatherForecastService : IWeatherForecastService 
        //This is the service class where the interface related to the class implementation is implemented.
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        public IEnumerable<WeatherForecast> Get() 
            //Can put anything here with DB calls and such with integrated business logics in them.
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
