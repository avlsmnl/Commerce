using Commerce.Core.Models;
using Commerce.Data.DataContext;

namespace Commerce.Lib.Customers.Updater;
public class CustomerUpdater : ICustomerUpdater
{
    private readonly ICommerceContext _commerceContext;

    public CustomerUpdater(ICommerceContext commerceContext)
    {
        _commerceContext = commerceContext;
    }
    public void UpdaterCustomer(Customer customer)
    {
        var existingCustomer = _commerceContext.Customers.GetValueOrDefault(customer.Id);
        if (existingCustomer != null)
        {
            _commerceContext.Customers[customer.Id] = customer;            
        }
    }
}