using Commerce.Core.Models;
using Commerce.Core.ResponseModels;
using Commerce.Lib.Customers.Manager;
using Commerce.Lib.Orders.Manager;
using Commerce.Lib.Products.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Api.Controllers;

[Consumes("application/json")]
[Produces("application/json")]
[Route("api/customers/{customerId}/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ICustomerManager _customerManager;
    private readonly IOrderManager _orderManager;
    private readonly IProductManager _productManager;

    public OrdersController(ICustomerManager customerManager, IOrderManager orderManager, IProductManager productManager)
    {
        _customerManager = customerManager;
        _orderManager = orderManager;
        _productManager = productManager;
    }

    [HttpPost]
    public IActionResult CreateOrder(Guid customerId, Order order)
    {        

        var (customerData, customerValidationErrors) = ValidateCustomerOrder(customerId);
        if (customerData == null)
        {            
            return BadRequest(new { Errors = customerValidationErrors });
        }

        if (order?.OrderLines?.Count() == 0)
        {
            return BadRequest(new { Errors = new List<Error> { new Error("orderLines", "The order must contain at least one product.") } });
        }

        var invalidProducts = ValidateOrderLines(order);
        if (invalidProducts.Any())
        {                        
            return BadRequest(new { Errors = invalidProducts });
        }

        order.CustomerId = customerId;
        return Ok(_orderManager.CreateOrder(order));
    }
    private (Customer?, List<Error>?) ValidateCustomerOrder(Guid customerId)
    {
        
        return _customerManager.GetCustomerById(customerId) is Customer customer ? 
            (customer, null): 
            (null, new List<Error> { new Error("customerId", "Invalid customerId") });

    }

    private IEnumerable<Error> ValidateOrderLines(Order order)
    {
        var productIds = order.OrderLines.Select(OrderLine => OrderLine.Sku).ToArray();
        var productsData = _productManager.GetProducts(productIds);
        var invalidProducts = productIds.Except(productsData.Select(product => product.Sku)).ToList();

        if (invalidProducts != null)
        {
            return invalidProducts.Select(invalidProduct => new Error(Property: "Sku", Message: $"The product {invalidProduct} does not exist."));
        }
        return new List<Error>();
    }
}