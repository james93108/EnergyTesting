﻿using EnergyTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyTest.DataContext
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
