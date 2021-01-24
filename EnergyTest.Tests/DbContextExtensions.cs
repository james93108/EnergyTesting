using EnergyTest.DataContext;
using EnergyTest.Models;
using System;

namespace EnergyTest.Tests
{
    public static class DbContextExtensions
    {
        public static void Seed(this CustomerDbContext dbContext)
        {
            // Add entities for DbContext instance
            dbContext.Customers.Add(new Customer
            {
                Id = 1,
                FirstName = "Bill",
                LastName = "Kaulitz",
                DateofBirth = new DateTime(1990, 12, 13)
            });

            dbContext.Customers.Add(new Customer
            {
                Id = 2,
                FirstName = "Lindsey",
                LastName = "Graham",
                DateofBirth = new DateTime(1994, 10, 26)
            });

            dbContext.SaveChanges();
        }
    }
}