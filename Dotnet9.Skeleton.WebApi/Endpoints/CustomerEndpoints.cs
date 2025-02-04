using Dotnet9.Skeleton.WebApi.Models;
using Dotnet9.Skeleton.WebApi.Repositories;
using Dotnet9.Skeleton.WebApi.Services;
using Dotnet9.Skeleton.WebApi.Validation;
using FluentValidation;

namespace Dotnet9.Skeleton.WebApi.Endpoints;

public static class CustomerEndpoints
{
    private const string RouteName = "api/customers";

    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(RouteName);
        group.MapGet("", GetAllCustomers)
            .WithName(nameof(GetAllCustomers));

        group.MapGet("{id}", GetCustomerById)
            .WithName(nameof(GetCustomerById));

        group.MapPost("/ex", CreateCustomerWithException)
            .WithName(nameof(CreateCustomerWithException));

        group.MapPost("", CreateCustomer)
            .WithName(nameof(CreateCustomer))
            .WithRequestValidation<Customer>();
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

    internal static IResult CreateCustomer(ICustomerService customerService, Customer customer)
    {
        var response = customerService.Create(customer);

        return response.IsSuccess
            ? Results.Created($"/{customer.Id}", response.Value)
            : Results.Problem(string.Join("; ", response.Errors));
    }
}
