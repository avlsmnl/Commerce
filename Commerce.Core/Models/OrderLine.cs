namespace Commerce.Core.Models;

public class OrderLine
{
    public OrderLine()
    {

    }
    /// <summary>
    /// The unique identifier for a product
    /// </summary>
    public string Sku { get; set; }
    /// <summary>
    /// The quantity requested
    /// </summary>
    public double Quantity { get; set; }
    /// <summary>
    /// The price for the selected product
    /// </summary>
    public double RetailPrice { get; set; }
}

