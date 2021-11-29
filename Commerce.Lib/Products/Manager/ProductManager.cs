using Commerce.Core.Models;
using Commerce.Lib.Products.Loader;

namespace Commerce.Lib.Products.Manager;
public class ProductManager : IProductManager
{
    private readonly IProductLoader _productLoader;

    public ProductManager(IProductLoader productLoader)
    {
        _productLoader = productLoader;
    }
    public IEnumerable<Product> GetProducts(string[] productIds = default!)
    {
        return _productLoader.GetProducts(productIds);
    }
}