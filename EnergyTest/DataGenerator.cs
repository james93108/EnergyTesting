using EnergyTest.DataContext;
using EnergyTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EnergyTest
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CustomerDbContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }

                context.Customers.AddRange(
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Bill",
                        LastName = "Kaulitz",
                        DateofBirth = new DateTime(1990, 12, 13)
                    },
                    new Customer
                    {
                        Id = 2,
                        FirstName = "Lindsey",
                        LastName = "Graham",
                        DateofBirth = new DateTime(1994, 10, 26)
                    });

                context.SaveChanges();
            }
        }
    }
}
