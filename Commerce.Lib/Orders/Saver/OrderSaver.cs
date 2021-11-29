using Commerce.Core.Models;
using Commerce.Data.DataContext;

namespace Commerce.Lib.Orders.Saver;

public class OrderSaver : IOrderSaver
{
    private readonly ICommerceContext _commerceContext;

    public OrderSaver(ICommerceContext commerceContext)
    {
        _commerceContext = commerceContext;
    }
    public bool CreateOrder(Order order)
    {
        _commerceContext.Orders.Add(order.Id, order);
        return true;
    }
}

