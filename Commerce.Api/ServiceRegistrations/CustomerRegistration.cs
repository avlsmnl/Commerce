using Commerce.Core.RequestModels;
using Commerce.Lib.Customers.Deleter;
using Commerce.Lib.Customers.Loader;
using Commerce.Lib.Customers.Manager;
using Commerce.Lib.Customers.Saver;
using Commerce.Lib.Customers.Updater;
using Commerce.Lib.Customers.Validator;
using FluentValidation;

namespace MinimalAPIs.ServiceRegistrations
{
    public static class CustomerRegistration
    {
        public static void AddCustomerRegistrations(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CustomerRequest>, CustomerRequestValidator>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomerDeleter, CustomersDeleter>();
            services.AddScoped<ICustomerLoader, CustomerLoader>();
            services.AddScoped<ICustomerSaver, CustomerSaver>();
            services.AddScoped<ICustomerUpdater, CustomerUpdater>();
        }
    }
}
