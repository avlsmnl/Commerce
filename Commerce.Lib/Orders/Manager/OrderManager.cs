using Commerce.Core.Models;
using Commerce.Lib.Discounts;
using Commerce.Lib.Orders.Saver;

namespace Commerce.Lib.Orders.Manager;

public class OrderManager : IOrderManager
{
    private readonly IOrderSaver _orderSaver;
    private readonly IDiscountHandler _discountHandler;

    public OrderManager(IOrderSaver orderSaver, IDiscountHandler discountHandler)
    {
        _orderSaver = orderSaver;
        _discountHandler = discountHandler;
    }

    public double CreateOrder(Order order)
    {
        var discountPercentage = _discountHandler.GetDiscountPercentage(order.CustomerId);
        _orderSaver.CreateOrder(order);        
        var total = order.OrderLines.Sum(orderLine => orderLine.Quantity * orderLine.RetailPrice);
        return (total - (total * discountPercentage));
    }
}