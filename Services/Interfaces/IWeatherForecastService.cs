namespace RepositoryDesignPattern.Services.Interfaces
{
    public interface IWeatherForecastService 
        //This is the service interface where the interface related to the class implementation is defined.
    {
        IEnumerable<WeatherForecast> Get();
    }
}
