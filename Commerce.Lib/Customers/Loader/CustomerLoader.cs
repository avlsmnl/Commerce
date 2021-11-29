using Commerce.Core.Models;
using Commerce.Data.DataContext;

namespace Commerce.Lib.Customers.Loader;

public class CustomerLoader : ICustomerLoader
{
    private readonly ICommerceContext _commerceContext;

    public CustomerLoader(ICommerceContext commerceContext)
    {
        _commerceContext = commerceContext;
    }
    public IEnumerable<Customer> Load()
    {
        return _commerceContext.Customers.Values;
    }

    public Customer? LoadById(Guid customerId)
    {
        return _commerceContext.Customers.GetValueOrDefault(customerId);
    }
}