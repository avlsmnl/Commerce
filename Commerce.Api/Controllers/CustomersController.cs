using Commerce.Core.Models;
using Commerce.Core.RequestModels;
using Commerce.Lib.Customers.Manager;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[Consumes("application/json")]
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{    
    private readonly ICustomerManager _customerManager;
    private readonly IValidator<CustomerRequest> _customerValidator;

    public CustomersController(ICustomerManager customerManager, IValidator<CustomerRequest> customerValidator)
    {        
        _customerManager = customerManager;
        _customerValidator = customerValidator;
    }

    /// <summary>
    /// Retrieves all the registered customers
    /// </summary>
    /// <returns></returns>    
    [HttpGet]    
    public IResult GetCustomers()
    {
        return Results.Ok(_customerManager.GetCustomers());
    }

    /// <summary>
    /// Returns the customer with the specified id
    /// </summary>
    /// <param name="customerId">The unique identifier for the customer to be retrieved</param>
    /// <returns>Customer</returns>
    [HttpGet("{customerId}")]   
    public IResult GetCustomerById(Guid customerId)
    {
        return _customerManager.GetCustomerById(customerId) is Customer customer
            ? Results.Ok(customer)
            : Results.NotFound();
    }


    /// <summary>
    /// Creates and returns the route where the customer can be retrieved.
    /// </summary>
    /// <param name="customerRequest">The data required to create a customer</param>
    /// <returns></returns>
    [HttpPost]
    public IResult CreateCustomer(CustomerRequest customerRequest)
    {        
        var validationResult = _customerManager.ValidateCustomer(customerRequest);
        if (!validationResult.IsValid)
        {
            return Results.UnprocessableEntity(validationResult.Errors.Select(error => new
            {
                Field = error.PropertyName,
                Error = error.ErrorMessage
            }));
        }

        // Add mapper
        var customer = new Customer
        {
            Name = customerRequest.Name
        };

        _customerManager.AddCustomer(customer);

        return Results.Created($"/api/customers/{customer.Id}", customer);

    }
    /// <summary>
    /// Updates an existing customer
    /// </summary>
    /// <param name="customerId">The unique identifier for the customer to be updated</param>
    /// <param name="customerRequest">The data required to update a customer</param>
    /// <returns></returns>
    [HttpPut("{customerId}")]
    public IResult UpdateCustomer(Guid customerId, CustomerRequest customerRequest)
    {
        
        var validationResult = _customerValidator.Validate(customerRequest);
        if (!validationResult.IsValid)
        {
            return Results.UnprocessableEntity(validationResult.Errors.Select(error => new
            {
                Field = error.PropertyName,
                Error = error.ErrorMessage
            }));
        }
        
        var existingCustomer = _customerManager.GetCustomerById(customerId);
        if (existingCustomer == null)
        {
            return Results.NotFound();
        }

        // Add mapper
        var customer = new Customer
        {
            Id = customerId,
            Name = customerRequest.Name
        };

        _customerManager.UpdateCustomer(customer);

        return Results.NoContent();
    }

    /// <summary>
    /// Deletes an existing customer.
    /// </summary>
    /// <param name="customerId">The unique identifier for the customer to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{customerId}")]
    public IResult DeleteCustomer(Guid customerId)
    {        
        var existingCustomer = _customerManager.GetCustomerById(customerId);
        if (existingCustomer == null)
        {
            return Results.NotFound();
        }

        
        var customerResult = _customerManager.DeleteCustomer(customerId);

        return customerResult ?
            Results.NoContent() :
            Results.Problem();
    }
}
