using Commerce.Core.Models;

namespace Commerce.Lib.Customers.Saver;

public interface ICustomerSaver
{
    void Save(Customer customer);
}