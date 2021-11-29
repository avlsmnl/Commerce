using Commerce.Core.Models;

namespace Commerce.Lib.Orders.Saver;

public interface IOrderSaver
{
    bool CreateOrder(Order order);
}