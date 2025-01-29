using Dotnet9.Skeleton.WebApi.Models;
using Dotnet9.Skeleton.WebApi.Services;

namespace Dotnet9.Skeleton.WebApi.Endpoints;

public static class WeatherForecastEndpoints
{
    public static void MapWeatherForecastEndpoints(this WebApplication app)
    {
        app.MapGet("api/weatherforecasts", GetWeatherForecasts);
    }

    public static void AddWeatherForecastServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
    }

    internal static WeatherForecast[] GetWeatherForecasts(IWeatherForecastService weatherForecastService)
    {
        return weatherForecastService.GetWeatherForecasts();
    }
}
