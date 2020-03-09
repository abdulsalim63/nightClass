using System;
using Microsoft.EntityFrameworkCore;
using Mediator.Domain.Entities;

namespace Mediator.Infrastructure
{
    public class ProjectConetxt : DbContext
    {
        public ProjectConetxt(DbContextOptions<ProjectConetxt> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(m => m.Order)
                .HasForeignKey(key => key.customer_id);
        }
    }
}
