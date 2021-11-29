using Commerce.Lib.Products.Loader;
using Commerce.Lib.Products.Manager;

namespace Commerce.Api.ServiceRegistrations
{
    public static class ProductRegistrations
    {
        public static void AddProductRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IProductManager, ProductManager>();
            services.AddTransient<IProductLoader, ProductLoader>();
        }
    }
}
