namespace Commerce.Lib.Orders.Loader;

public interface IOrderLoader
{
    int CountOrdersByCustomer(Guid customerId);
}

