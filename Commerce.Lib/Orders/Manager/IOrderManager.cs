using Commerce.Core.Models;

namespace Commerce.Lib.Orders.Manager;

public interface IOrderManager
{
    double CreateOrder(Order order);
}

