using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lil.Search.Controllers;
using Lil.Search.Interfaces;
using Lil.Search.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lil.Search.Tests
{
    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void SearchAsyncReturnsOk()
        {
            // Setup
            Mock<ICustomersService> customersService = new Mock<ICustomersService>();
            Mock<IProductsService> productsService = new Mock<IProductsService>();
            Mock<ISalesService> salesService = new Mock<ISalesService>();

            Customer customer = new Customer
            {
                Id = "1",
                Name = "Customer 1",
                City = "City 1"
            };
            Product product = new Product
            {
                Id = "1",
                Name = "Product Test",
                Price = 100
            };
            ICollection<Order> order = new List<Order>
            {
                new Order
                {
                    Id = "1",
                    CustomerId = "1",
                    OrderDate = DateTime.Now,
                    Total = 100,
                    Items = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Id = 1,
                            OrderId = "1",
                            Price = 100,
                            Quantity = 1,
                            ProductId = "1"
                        }
                    }
                }
            };

            customersService.Setup(x => x.GetAsync("1")).Returns(Task.FromResult(customer));
            productsService.Setup(x => x.GetAsync("1")).Returns(Task.FromResult(product));
            salesService.Setup(x => x.GetAsync("1")).Returns(Task.FromResult(order));

            var controller = new SearchController(customersService.Object, productsService.Object, salesService.Object);

            // Act
            var result = controller.SearchAsync("1").Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
