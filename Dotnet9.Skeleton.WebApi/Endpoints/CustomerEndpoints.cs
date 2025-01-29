using Dotnet9.Skeleton.WebApi.Models;
using Dotnet9.Skeleton.WebApi.Repositories;
using Dotnet9.Skeleton.WebApi.Services;
using Dotnet9.Skeleton.WebApi.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace Dotnet9.Skeleton.WebApi.Endpoints;

public static class CustomerEndpoints
{
    private const string RouteName = "api/customers";

    public static void MapCustomerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(RouteName);
        group.MapGet("", GetAllCustomers)
            .WithName(nameof(GetAllCustomers));
        // TODO:  .AddEndpointFilter

        group.MapGet("{id}", GetCustomerById)
            .WithName(nameof(GetCustomerById));

        group.MapPost("/ex", CreateCustomerWithException)
            .WithName(nameof(CreateCustomerWithException));

        group.MapPost("", CreateCustomer)
            .WithName(nameof(CreateCustomer));
    }

    public static void AddCustomerServices(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
        services.AddSingleton<ICustomerService, CustomerService>();
        services.AddScoped<IValidator<Customer>, CustomerValidator>();
    }

    internal static List<Customer> GetAllCustomers(ICustomerService customerService)
    {
        return customerService.GetAll();
    }

    internal static IResult GetCustomerById(ICustomerService customerService, int id)
    {
        var response = customerService.GetById(id);

        return response.IsSuccess
            ? Results.Ok(response.Value)
            : Results.NotFound(response.Errors);
    }

    // global exception handling with problemDetails example
    internal static void CreateCustomerWithException(Customer customer)
    {
        throw new ApplicationException("I'm an exception");
    }

    internal static async Task<IResult> CreateCustomer(IValidator<Customer> validator, ICustomerService customerService, Customer customer)
    {
        ValidationResult validationResult = await validator.ValidateAsync(customer);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var response = customerService.Create(customer);

        return response.IsSuccess
            ? Results.Created($"/{customer.Id}", response.Value)
            : Results.Problem(string.Join("; ", response.Errors));
    }
}
