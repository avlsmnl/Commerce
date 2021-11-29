using Commerce.Data.DataContext;

namespace Commerce.Lib.Orders.Loader;

public class OrderLoader: IOrderLoader
{
    private readonly ICommerceContext _commerceContext;

    public OrderLoader(ICommerceContext commerceContext)
    {
        _commerceContext = commerceContext;
    }

    public int CountOrdersByCustomer(Guid customerId)
    {
        return _commerceContext.Orders.Values
            .Count(order => order.CustomerId == customerId);
    }
}

