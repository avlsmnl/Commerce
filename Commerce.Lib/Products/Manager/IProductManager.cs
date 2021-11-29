using Commerce.Core.Models;

namespace Commerce.Lib.Products.Manager;
public interface IProductManager
{
    IEnumerable<Product> GetProducts(string[] productIds = default!);
}