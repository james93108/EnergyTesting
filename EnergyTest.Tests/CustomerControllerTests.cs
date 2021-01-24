using EnergyTest.Controllers;
using EnergyTest.DataContext;
using EnergyTest.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EnergyTest.Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        CustomerDbContext customerDbContext;
        CustomerController customerController;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetCustomers()
        {
            // Arrange
            customerDbContext = DbContextMocker.GetCustomerDbContext(nameof(TestGetCustomers));
            customerController = new CustomerController(customerDbContext);

            // Act
            var actionResult = customerController.GetCustomers();

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(200, (actionResult as OkObjectResult).StatusCode);
            Assert.AreEqual(2, ((actionResult as OkObjectResult).Value as List<Customer>).Count);
        }

        [Test]
        public void TestGetCustomer()
        {
            // Arrange
            customerDbContext = DbContextMocker.GetCustomerDbContext(nameof(TestGetCustomer));
            customerController = new CustomerController(customerDbContext);

            // Act
            var actionResult = customerController.GetCustomer(1);

            // Assert
            Assert.AreEqual("Bill", ((actionResult as OkObjectResult).Value as Customer).FirstName);

        }

        [Test]
        public void TestAddCustomer()
        {
            // Arrange
            customerDbContext = DbContextMocker.GetCustomerDbContext(nameof(TestAddCustomer));
            customerController = new CustomerController(customerDbContext);

            Customer customer = new Customer
            {
                Id = 3,
                FirstName = "Liam",
                LastName = "Kennedy",
                DateofBirth = new DateTime(1988, 7, 9)
            };

            // Act
            var actionResult = customerController.AddCustomer(customer);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(actionResult);
            Assert.AreEqual(3, ((actionResult as OkObjectResult).Value as Customer).Id);
        }

        [Test]
        public void TestEditCustomer()
        {
            // Arrange
            customerDbContext = DbContextMocker.GetCustomerDbContext(nameof(TestEditCustomer));
            customerController = new CustomerController(customerDbContext);

            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "John",
                LastName = "Kaulitz",
                DateofBirth = new DateTime(1990, 12, 13)
            };

            // Act
            var actionResult = customerController.EditCustomer(1, customer);

            // Assert
            Assert.AreEqual("John", ((actionResult as OkObjectResult).Value as Customer).FirstName);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            // Arrange
            customerDbContext = DbContextMocker.GetCustomerDbContext(nameof(TestDeleteCustomer));
            customerController = new CustomerController(customerDbContext);

            // Act
            var actionResult = customerController.DeleteCustomer(1);

            // Assert
            Assert.AreEqual("Kaulitz", ((actionResult as OkObjectResult).Value as Customer).LastName);
        }

        [Test]
        public void TestSearchCustomer()
        {
            // Arrange
            customerDbContext = DbContextMocker.GetCustomerDbContext(nameof(TestSearchCustomer));
            customerController = new CustomerController(customerDbContext);

            // Act
            var actionResult = customerController.SearchCustomer("Graham");

            // Assert
            Assert.AreEqual(1, ((actionResult as OkObjectResult).Value as List<Customer>).Count);
        }
    }
}