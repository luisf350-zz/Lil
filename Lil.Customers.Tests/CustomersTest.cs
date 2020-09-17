using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lil.Customers.Tests
{
    [TestClass]
    public class CustomersTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {
            // Setup
            var customerProvider = new CustomersProvider();
            var controller = new CustomersController(customerProvider);

            // Act
            var result = controller.GetAsync("1").Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAsyncReturnsNotFound()
        {
            // Setup
            var customerProvider = new CustomersProvider();
            var controller = new CustomersController(customerProvider);

            // Act
            var result = controller.GetAsync("99").Result;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
