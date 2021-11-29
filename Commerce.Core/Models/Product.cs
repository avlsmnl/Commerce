namespace Commerce.Core.Models;

public class Product
{
    public Product()
    {

    }
    /// <summary>
    /// The unique identifier for a product
    /// </summary>
    public string Sku { get; set; } = default!;
    /// <summary>
    /// The name to be displayed for a product
    /// </summary>
    public string Name { get; init; } = default!;
}
