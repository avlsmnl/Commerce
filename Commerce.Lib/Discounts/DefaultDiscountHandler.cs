using Commerce.Lib.Orders.Loader;

namespace Commerce.Lib.Discounts;

public class DefaultDiscountHandler : IDiscountHandler
{
    private readonly IOrderLoader _orderLoader;

    public DefaultDiscountHandler(IOrderLoader orderLoader)
    {
        _orderLoader = orderLoader;
    }

    public double GetDiscountPercentage(Guid customerId)
    {
        var ordersRegistered = _orderLoader.CountOrdersByCustomer(customerId);
        return ordersRegistered switch
        {
           > 0 and < 3 => 0.01,
           >= 3 and < 6 => 0.02,
           >= 6 and < 11 => 0.05,
           > 10 => 0.1,
            _ => 0
        };
    }
}
