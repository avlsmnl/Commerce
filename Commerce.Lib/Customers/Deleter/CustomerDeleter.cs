using Commerce.Data.DataContext;

namespace Commerce.Lib.Customers.Deleter;

public class CustomersDeleter : ICustomerDeleter
{
    private readonly ICommerceContext _commerceContext;

    public CustomersDeleter(ICommerceContext commerceContext)
    {
        _commerceContext = commerceContext;
    }

    public bool Delete(Guid customerId)
    {
        return _commerceContext.Customers.Remove(customerId);
    }
}