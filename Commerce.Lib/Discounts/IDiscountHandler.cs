namespace Commerce.Lib.Discounts;

public interface IDiscountHandler
{
    double GetDiscountPercentage(Guid customerId);
}
