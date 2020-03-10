using System;
using Hangfires.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hangfires.Infrastructure
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
    }
}
