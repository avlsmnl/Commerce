namespace Commerce.Core.Models;

public class Order
{
    public Order()
    {

    }
    /// <summary>
    /// The unique identifier for an order
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();
    /// <summary>
    /// The customerId which owns this order
    /// </summary>
    public Guid CustomerId { get; set; }
    /// <summary>
    /// The order lines for this order.
    /// </summary>
    public IEnumerable<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    /// <summary>
    /// The total amount for this order
    /// </summary>
    public decimal Total { get; init; } = default!;
}

