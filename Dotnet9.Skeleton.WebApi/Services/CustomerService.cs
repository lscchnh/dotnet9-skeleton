using Dotnet9.Skeleton.WebApi.Models;
using Dotnet9.Skeleton.WebApi.Options;
using Dotnet9.Skeleton.WebApi.Repositories;
using FluentResults;
using Microsoft.Extensions.Options;

namespace Dotnet9.Skeleton.WebApi.Services;

public interface ICustomerService
{
    List<Customer> GetAll();
    Result<Customer> GetById(int id);
    Result<Customer> Create(Customer customer);
}

public class CustomerService(IOptionsMonitor<CustomerOptions> customerOptions, ICustomerRepository customerRepository) : ICustomerService
{
    public List<Customer> GetAll()
    {
        return customerRepository.GetAll();
    }

    public Result<Customer> GetById(int id)
    {
        Customer? customer = customerRepository.GetById(id);

        return customer is not null
            ? Result.Ok(customer)
            : Result.Fail($"Customer {id} from {customerOptions.CurrentValue.Company} not found.");
    }

    public Result<Customer> Create(Customer customer)
    {
        Customer? createdCustomer = customerRepository.Create(customer);

        return createdCustomer is not null
            ? Result.Ok(customer)
            : Result.Fail($"Error when creating customer from {customerOptions.CurrentValue.Company}: {customer}.");
    }
}
