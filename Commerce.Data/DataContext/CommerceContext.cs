using Commerce.Core.Models;

namespace Commerce.Data.DataContext;

public class CommerceContext : ICommerceContext
{
    public CommerceContext()
    {
        GetProductsData();
    }
    public Dictionary<Guid, Customer> Customers { get; set; } = new();
    public Dictionary<Guid, Order> Orders { get; set; } = new();
    public Dictionary<Guid, Product> Products { get; } = new();

    private void GetProductsData()
    {
        for (int i = 0; i < 10; i++)
        {
            Products.Add(Guid.NewGuid(), new Product { Sku = $"A{i.ToString("0000")}", Name = $"Product{i}" });
        }
    }
}
