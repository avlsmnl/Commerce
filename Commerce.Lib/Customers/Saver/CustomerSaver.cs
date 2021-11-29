using Commerce.Core.Models;
using Commerce.Data.DataContext;

namespace Commerce.Lib.Customers.Saver;

public class CustomerSaver : ICustomerSaver
{
    private readonly ICommerceContext _commerceContext;

    public CustomerSaver(ICommerceContext commerceContext)
    {
        _commerceContext = commerceContext;
    }

    public void Save(Customer customer)
    {        
        _commerceContext.Customers.Add(customer.Id, customer);        
    }
}