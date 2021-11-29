namespace Commerce.Core.Models;

public class Customer
{
    public Customer()
    {

    }
    /// <summary>
    /// Unique identifier for a customer
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>
    /// Customer name
    /// </summary>
    public string Name { get; init; } = default!;
}
