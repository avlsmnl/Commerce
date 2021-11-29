using Commerce.Lib.Discounts;
using Commerce.Lib.Orders.Loader;
using NSubstitute;
using System;
using Xunit;

namespace Commerce.Tests.Lib.Discounts;

public class DefaultDiscountsHandlerTests
{
    [Fact]
    public void GetDiscountPercentage_ReturnsOnePercent_WhenCustomerOrdersCountAreBetweenOneAndTwo()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedValue = 0.01;
        var orderLoader = Substitute.For<IOrderLoader>();
        orderLoader.CountOrdersByCustomer(customerId).Returns(1);
        var discountHandler = new DefaultDiscountHandler(orderLoader);

        // Act
        var currentPercentage = discountHandler.GetDiscountPercentage(customerId);

        // Assert
        Assert.True(expectedValue == currentPercentage);

    }

    [Fact]
    public void GetDiscountPercentage_ReturnsOnePercent_WhenCustomerOrdersCountAreBetweenThreeAndFive()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedValue = 0.02;
        var orderLoader = Substitute.For<IOrderLoader>();
        orderLoader.CountOrdersByCustomer(customerId).Returns(5);
        var discountHandler = new DefaultDiscountHandler(orderLoader);

        // Act
        var currentPercentage = discountHandler.GetDiscountPercentage(customerId);

        // Assert
        Assert.True(expectedValue == currentPercentage);

    }

    [Fact]
    public void GetDiscountPercentage_ReturnsOnePercent_WhenCustomerOrdersCountAreBetweenSixAndTen()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedValue = 0.05;
        var orderLoader = Substitute.For<IOrderLoader>();
        orderLoader.CountOrdersByCustomer(customerId).Returns(8);
        var discountHandler = new DefaultDiscountHandler(orderLoader);

        // Act
        var currentPercentage = discountHandler.GetDiscountPercentage(customerId);

        // Assert
        Assert.True(expectedValue == currentPercentage);

    }

    [Fact]
    public void GetDiscountPercentage_ReturnsOnePercent_WhenCustomerOrdersCountAreGreaterThanTen()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedValue = 0.1;
        var orderLoader = Substitute.For<IOrderLoader>();
        orderLoader.CountOrdersByCustomer(customerId).Returns(16);
        var discountHandler = new DefaultDiscountHandler(orderLoader);

        // Act
        var currentPercentage = discountHandler.GetDiscountPercentage(customerId);

        // Assert
        Assert.True(expectedValue == currentPercentage);

    }

    [Fact]
    public void GetDiscountPercentage_ReturnsOnePercent_WhenACustomeDoesnotHaveOrders()
    {
        // Arrange
        var customerId = Guid.NewGuid();
        var expectedValue = 0;
        var orderLoader = Substitute.For<IOrderLoader>();
        orderLoader.CountOrdersByCustomer(customerId).Returns(0);
        var discountHandler = new DefaultDiscountHandler(orderLoader);

        // Act
        var currentPercentage = discountHandler.GetDiscountPercentage(customerId);

        // Assert
        Assert.True(expectedValue == currentPercentage);

    }
}

/*

// Arrange

// Act

// Assert
  
 */ 