using Dotnet9.Skeleton.WebApi.Models;
using Dotnet9.Skeleton.WebApi.Repositories;
using Dotnet9.Skeleton.WebApi.Services;

namespace Dotnet9.Skeleton.WebApi.Endpoints;

public static class CustomerEndpoints
{
    private const string RouteName = "api/customers";

    public static void MapCustomerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup(RouteName);
        group.MapGet("", GetAllCustomers).WithName(nameof(GetAllCustomers));
        group.MapGet("{id}", GetCustomerById).WithName(nameof(GetCustomerById));
    }

    public static void AddCustomerServices(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
        services.AddSingleton<ICustomerService, CustomerService>();
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
}
