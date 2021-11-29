using Commerce.Core.Models;

namespace Commerce.Lib.Products.Loader;
public interface IProductLoader
{
    IEnumerable<Product> GetProducts(string[] productIds = default!);
}