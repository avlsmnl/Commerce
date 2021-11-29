namespace Commerce.Lib.Customers.Deleter;

public interface ICustomerDeleter
{
    bool Delete(Guid customerId);
}