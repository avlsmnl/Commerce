using Commerce.Core.Models;
using Commerce.Lib.Customers.Deleter;
using Commerce.Lib.Customers.Loader;
using Commerce.Lib.Customers.Manager;
using Commerce.Lib.Customers.Saver;
using NSubstitute;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Commerce.Lib.Customers.Updater;
using Commerce.Core.RequestModels;
using FluentValidation;
using FluentValidation.Results;

namespace Commerce.Tests.Lib.Customers;

public class CustomerManagerTests
{
    [Fact]
    public void GetCustomer_ReturnsData()
    {
        // Arrange        
        var customerDeleter = Substitute.For<ICustomerDeleter>();
        var customerLoader = Substitute.For<ICustomerLoader>();
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();
        customerLoader.Load().Returns(GetCustomers());
        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        var customers = customerManager.GetCustomers();

        // Assert
        Assert.True(customers.Count() == 2);
    }

    [Fact]
    public void GetCustomerById_ReturnsData()
    {
        // Arrange
        var customerId = Guid.Parse("fe1239d9-f040-4509-a9a7-66b001d34031");
        var customerDeleter = Substitute.For<ICustomerDeleter>();
        var customerLoader = Substitute.For<ICustomerLoader>();
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();
        customerLoader.LoadById(customerId).Returns(GetCustomers().First());
        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        var customer = customerManager.GetCustomerById(customerId);

        // Assert
        Assert.IsAssignableFrom<Customer>(customer);
        Assert.NotNull(customer);
        Assert.Equal(customerId, customer?.Id);
        Assert.Equal("avls", customer?.Name);
        
    }

    [Fact]
    public void ValidateCustomer_ReturnsNoErrors_ForAValidCustomer()
    {
        // Arrange        
        var customerDeleter = Substitute.For<ICustomerDeleter>();        
        var customerLoader = Substitute.For<ICustomerLoader>();        
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();

        var customerRequest = new CustomerRequest { Name = "avls" };
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();
        customerValidator.Validate(customerRequest).ReturnsForAnyArgs(new ValidationResult());

        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        var validationResult  = customerManager.ValidateCustomer(customerRequest);

        // Assert
        Assert.True(validationResult.IsValid);

    }

    [Fact]
    public void ValidateCustomer_ReturnsErrors_ForAnInvalidCustomer()
    {
        // Arrange        
        var customerDeleter = Substitute.For<ICustomerDeleter>();
        var customerLoader = Substitute.For<ICustomerLoader>();
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();

        var customerRequest = new CustomerRequest { Name = "" };
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();
        customerValidator.Validate(customerRequest).ReturnsForAnyArgs(new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Name", "Name must not be empty/null") }));

        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        var validationResult = customerManager.ValidateCustomer(customerRequest);

        // Assert
        Assert.False(validationResult.IsValid);
        Assert.NotEmpty(validationResult.Errors);
        Assert.Equal("Name", validationResult.Errors[0].PropertyName);
        Assert.Equal("Name must not be empty/null", validationResult.Errors[0].ErrorMessage);
        
    }


    [Fact]
    public void AddCustomer_GetsCalled()
    {
        // Arrange        
        var customerDeleter = Substitute.For<ICustomerDeleter>();
        var customerLoader = Substitute.For<ICustomerLoader>();
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();

        var customer = new Customer { Name = "avls" };
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();        
        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        customerManager.AddCustomer(customer);

        // Assert
        customerSaver.Received().Save(customer);
    }

    [Fact]
    public void UpdateCustomer_GetsCalled()
    {
        // Arrange        
        var customerDeleter = Substitute.For<ICustomerDeleter>();
        var customerLoader = Substitute.For<ICustomerLoader>();
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();

        var customer = new Customer { Name = "avls" };
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();
        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        customerManager.UpdateCustomer(customer);

        // Assert
        customerUpdater.Received().UpdaterCustomer(customer);
    }

    [Fact]
    public void DeleteCustomer_ReturnsTrue_WhenTheCustomerHasBeenRemoved()
    {
        // Arrange        
        var customerId = Guid.Parse("fe1239d9-f040-4509-a9a7-66b001d34031");
        var customerDeleter = Substitute.For<ICustomerDeleter>();
        var customerLoader = Substitute.For<ICustomerLoader>();
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();

        customerDeleter.Delete(customerId).Returns(true);
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();
        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        var deleteResult = customerManager.DeleteCustomer(customerId);

        // Assert
        Assert.True(deleteResult);
    }

    [Fact]
    public void DeleteCustomer_ReturnsFalse_WhenTheCustomerWasNotAbleToBeRemoved()
    {
        // Arrange        
        var customerId = Guid.Parse("fe1239d9-f040-4509-a9a7-66b001d34031");
        var customerDeleter = Substitute.For<ICustomerDeleter>();
        var customerLoader = Substitute.For<ICustomerLoader>();
        var customerUpdater = Substitute.For<ICustomerUpdater>();
        var customerSaver = Substitute.For<ICustomerSaver>();

        customerDeleter.Delete(customerId).Returns(false);
        var customerValidator = Substitute.For<AbstractValidator<CustomerRequest>>();
        var customerManager = new CustomerManager(customerSaver, customerLoader, customerDeleter, customerUpdater, customerValidator);

        // Act
        var deleteResult = customerManager.DeleteCustomer(customerId);

        // Assert
        Assert.False(deleteResult);
    }
    private IEnumerable<Customer> GetCustomers() => new List<Customer>()
    {
        new Customer() { Id = Guid.Parse("fe1239d9-f040-4509-a9a7-66b001d34031"), Name = "avls"},
        new Customer() { Id = Guid.Parse("fe1239d9-f040-4509-a9a7-66b001d34030"), Name = "mnl"}
    };
}