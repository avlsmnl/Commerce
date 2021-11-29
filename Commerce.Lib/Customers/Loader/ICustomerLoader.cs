using Commerce.Core.Models;

namespace Commerce.Lib.Customers.Loader;

public interface ICustomerLoader
{
    IEnumerable<Customer> Load();
    Customer? LoadById(Guid customerId);
}