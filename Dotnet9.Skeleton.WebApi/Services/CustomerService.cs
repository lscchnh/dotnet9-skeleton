using Dotnet9.Skeleton.WebApi.Models;
using Dotnet9.Skeleton.WebApi.Repositories;
using FluentResults;

namespace Dotnet9.Skeleton.WebApi.Services;

public interface ICustomerService
{
    List<Customer> GetAll();
    Result<Customer> GetById(int id);
}

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public List<Customer> GetAll()
    {
        return customerRepository.GetAll();
    }

    public Result<Customer> GetById(int id)
    {
        Customer? customer = customerRepository.GetById(id);

        return customer is not null ? Result.Ok(customer) : Result.Fail($"Customer {id} not found");
    }
}
