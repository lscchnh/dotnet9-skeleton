using Dotnet9.Skeleton.WebApi.Models;

namespace Dotnet9.Skeleton.WebApi.Services;

public interface IWeatherForecastService
{
    WeatherForecast[] GetWeatherForecasts();
}

public class WeatherForecastService : IWeatherForecastService
{
    public readonly string[] summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public WeatherForecast[] GetWeatherForecasts()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
               new WeatherForecast
               (
                   DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                   Random.Shared.Next(-20, 55),
                   summaries[Random.Shared.Next(summaries.Length)]
               ))
               .ToArray();

        return forecast;
    }
}