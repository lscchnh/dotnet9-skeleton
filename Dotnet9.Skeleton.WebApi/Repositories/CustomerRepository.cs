using Dotnet9.Skeleton.WebApi.Models;

namespace Dotnet9.Skeleton.WebApi.Repositories;

public interface ICustomerRepository
{
    List<Customer> GetAll();
    Customer? GetById(int id);
}

public class CustomerRepository : ICustomerRepository
{
    public readonly string[] customersNames =
    [
        "Pierre", "Paul", "Jacques"
    ];

    public List<Customer> GetAll()
    {
        return
            Enumerable.Range(0, customersNames.Length)
            .Select(index => new Customer(index, customersNames[index]))
            .ToList();
    }

    public Customer? GetById(int id)
    {
        List<Customer> customers = GetAll();

        return customers.FirstOrDefault(c => c.Id == id);
    }
}