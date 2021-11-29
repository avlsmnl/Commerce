using Commerce.Lib.Discounts;
using Commerce.Lib.Orders.Loader;
using Commerce.Lib.Orders.Manager;
using Commerce.Lib.Orders.Saver;

namespace Commerce.Api.ServiceRegistrations
{
    public static class OrderRegistrations
    {
        public static void AddOrderRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderSaver, OrderSaver>();
            services.AddTransient<IOrderLoader, OrderLoader>();
            services.AddScoped<IDiscountHandler, DefaultDiscountHandler>();
        }
    }
}
