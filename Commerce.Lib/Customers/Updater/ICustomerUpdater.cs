using Commerce.Core.Models;

namespace Commerce.Lib.Customers.Updater;

public interface ICustomerUpdater
{
    void UpdaterCustomer(Customer customer);
}