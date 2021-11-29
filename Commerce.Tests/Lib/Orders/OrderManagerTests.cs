using Commerce.Core.Models;
using Commerce.Lib.Discounts;
using Commerce.Lib.Orders.Manager;
using Commerce.Lib.Orders.Saver;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Commerce.Tests.Lib.Orders;

public class OrderManagerTests
{
    private readonly Guid customerId = Guid.Parse("fe1239d9-f040-4509-a9a7-66b001d34031");


    [Fact]
    public void CreateOrder_ReturnsThePurchaseCost()
    {
        // Arrange
        var orderData = GetOrderData();
        var orderSaver = Substitute.For<IOrderSaver>();        
        var defaultDiscountHandler = Substitute.For<IDiscountHandler>();
        defaultDiscountHandler.GetDiscountPercentage(customerId).Returns(0.01);
        var orderManager = new OrderManager(orderSaver, defaultDiscountHandler);

        // Act
        var orderCreationResult = orderManager.CreateOrder(orderData);

        // Assert
        orderSaver.Received().CreateOrder(orderData);
        Assert.IsType<double>(orderCreationResult);
        Assert.Equal(99, orderCreationResult);
    }

    private Order GetOrderData() => new Order
    {
        CustomerId = customerId,
        OrderLines = new List<OrderLine>
        {
            new OrderLine()
            {
                Quantity = 1,
                RetailPrice = 100,
                Sku = "A1001"
            }
        }
    };
}
