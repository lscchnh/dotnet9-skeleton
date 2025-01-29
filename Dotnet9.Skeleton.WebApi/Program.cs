using Dotnet9.Skeleton.WebApi.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddWeatherForecastServices();
builder.Services.AddCustomerServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        // workaround to tell scalar to use host port instead of container port (when launching on docker mode)
        options.Servers = Array.Empty<ScalarServer>();
    });
}

app.UseHttpsRedirection();

app.MapWeatherForecastEndpoints();
app.MapCustomerEndpoints();

app.Run();
