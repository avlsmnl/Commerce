using Commerce.Core.Models;
using Commerce.Data.DataContext;

namespace Commerce.Lib.Products.Loader;

public class ProductLoader : IProductLoader
{
    private readonly ICommerceContext _commerceContext;

    public ProductLoader(ICommerceContext commerceContext)
    {
        _commerceContext = commerceContext;
    }
    public IEnumerable<Product> GetProducts(string[] productIds = default!)
    {
        if (productIds == null)
        {
            return _commerceContext.Products.Values.ToList();
        }
        return _commerceContext.Products.Values.Where(product => productIds.Contains(product.Sku)).ToList() ?? new List<Product>();
    }
}
