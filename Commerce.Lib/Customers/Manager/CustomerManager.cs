using Commerce.Core.Models;
using Commerce.Core.RequestModels;
using Commerce.Lib.Customers.Deleter;
using Commerce.Lib.Customers.Loader;
using Commerce.Lib.Customers.Saver;
using Commerce.Lib.Customers.Updater;
using FluentValidation;
using FluentValidation.Results;

namespace Commerce.Lib.Customers.Manager;

public class CustomerManager : ICustomerManager
{
    private readonly ICustomerSaver _customerSaver;
    private readonly ICustomerLoader _customerLoader;
    private readonly ICustomerDeleter _customerDeleter;
    private readonly ICustomerUpdater _customerUpdater;
    private readonly IValidator<CustomerRequest> _customerRequestValidator;

    public CustomerManager(ICustomerSaver customerSaver, 
        ICustomerLoader customerLoader, 
        ICustomerDeleter customerDeleter, 
        ICustomerUpdater customerUpdater,
        IValidator<CustomerRequest> customerRequestValidator)
    {
        _customerSaver = customerSaver;
        _customerLoader = customerLoader;
        _customerDeleter = customerDeleter;
        _customerUpdater = customerUpdater;
        _customerRequestValidator = customerRequestValidator;
    }

    public void AddCustomer(Customer customer)
    {
        _customerSaver.Save(customer);
    }

    public bool DeleteCustomer(Guid customerId)
    {
        return _customerDeleter.Delete(customerId);
    }

    public Customer? GetCustomerById(Guid customerId)
    {
        return _customerLoader.LoadById(customerId);
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return _customerLoader.Load();
    }

    public void UpdateCustomer(Customer customer)
    {
        _customerUpdater.UpdaterCustomer(customer);
    }

    public ValidationResult ValidateCustomer(CustomerRequest customerRequest)
    {
        return _customerRequestValidator.Validate(customerRequest);
    }
}