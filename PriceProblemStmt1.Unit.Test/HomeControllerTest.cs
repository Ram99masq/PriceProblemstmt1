using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PriceProblemstmt1.BusinessLayer;
using ProblemStatement1.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace PriceProblemStmt1.Unit.Test
{
    public class HomeControllerTest
    {
        private readonly Mock<ILogger<HomeController>> logger;
        List<Item> _items = null;

        public HomeControllerTest()
        {
            _items = new List<Item>();
            logger = new Mock<ILogger<HomeController>>();
        }

        [Fact]
        public void Fetch_ItemPrice_ScenarioA_Return_100_Successful()
        {
            _items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 1 });
            _items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 1 });
            _items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });

            // Act
            var controller = new HomeController(logger.Object);
            var response = controller.GetItemPrice(_items);
            // Assert
            Assert.IsType<OkObjectResult>(response);
            var okResult = response as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(100.00, okResult.Value);
            // finalprice = Total = 100
        }


        [Fact]
        public void Fetch_ItemPrice_ScenarioB_Return_370_Successful()
        {
            _items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 5 });
            _items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 5 });
            _items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            // finalprice = Total = 370
            // Act
            var controller = new HomeController(logger.Object);
            var response = controller.GetItemPrice(_items);
            // Assert
            Assert.IsType<OkObjectResult>(response);
            var okResult = response as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(370.00, okResult.Value);
            // finalprice = Total = 370
        }


        [Fact]
        public void Fetch_ItemPrice_ScenarioC_Return_280_Successful()
        {
            _items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 3 });
            _items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 5 });
            _items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            _items.Add(new Item() { ItemID = "D", UnitPrice = 15, OrderItems = 1 });
            // finalprice = Total = 280
            // Act
            var controller = new HomeController(logger.Object);
            var response = controller.GetItemPrice(_items);
            // Assert
            Assert.IsType<OkObjectResult>(response);
            var okResult = response as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(280.00, okResult.Value);
            // finalprice = Total = 280
        }

        [Fact]
        public void Fetch_ItemPrice_ScenarioCustomCase_With_ABCD_Return_205_Successful()
        {
            _items.Add(new Item() { ItemID = "A", UnitPrice = 50, OrderItems = 3 });
            _items.Add(new Item() { ItemID = "B", UnitPrice = 30, OrderItems = 2 });
            _items.Add(new Item() { ItemID = "C", UnitPrice = 20, OrderItems = 1 });
            _items.Add(new Item() { ItemID = "D", UnitPrice = 15, OrderItems = 1 });
            // finalprice = Total = 205
            // Act
            var controller = new HomeController(logger.Object);
            var response = controller.GetItemPrice(_items);
            // Assert
            Assert.IsType<OkObjectResult>(response);
            var okResult = response as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(205.00, okResult.Value);
            // finalprice = Total = 205

        }

        [Fact]
        public void Fetch_ItemPrice_NullObject_Return_205_Successful()
        {
            //Given
            _items = null;
            //Act
            var controller = new HomeController(logger.Object);
            var result = controller.GetItemPrice(_items) as BadRequestObjectResult;

            // assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal($"Invalid ItemList : {_items} while Fetching PriceAmount", result.Value);
        }
    }
}
