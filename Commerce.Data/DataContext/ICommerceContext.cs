using Commerce.Core.Models;

namespace Commerce.Data.DataContext;

public interface ICommerceContext
{
    public Dictionary<Guid, Customer> Customers { get; set; }
    public Dictionary<Guid, Order> Orders { get; set; }
    public Dictionary<Guid, Product> Products { get; }
}
