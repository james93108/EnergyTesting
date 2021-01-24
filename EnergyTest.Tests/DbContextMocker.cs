using EnergyTest.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EnergyTest.Tests
{
    public static class DbContextMocker
    {
        public static CustomerDbContext GetCustomerDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new CustomerDbContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
