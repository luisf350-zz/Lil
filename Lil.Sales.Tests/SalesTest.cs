using Lil.Sales.Controllers;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Sales.Tests
{
    [TestClass]
    public class SalesTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            // Setup
            var customerProvider = new SalesProvider();
            var customersController = new SalesController(customerProvider);

            // Act
            var result = customersController.GetAsync("1").Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            // Setup
            var customerProvider = new SalesProvider();
            var customersController = new SalesController(customerProvider);

            // Act
            var result = customersController.GetAsync("99").Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
