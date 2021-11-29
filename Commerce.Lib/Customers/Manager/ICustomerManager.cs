using Commerce.Core.Models;
using Commerce.Core.RequestModels;
using FluentValidation.Results;

namespace Commerce.Lib.Customers.Manager;

public interface ICustomerManager
{
    IEnumerable<Customer> GetCustomers();
    Customer? GetCustomerById(Guid customerId);
    void UpdateCustomer(Customer customer);
    void AddCustomer(Customer customer);
    bool DeleteCustomer(Guid customerId);
    ValidationResult ValidateCustomer(CustomerRequest customerRequest);
}
