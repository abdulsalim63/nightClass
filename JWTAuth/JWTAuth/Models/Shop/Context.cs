using System;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Models.Shop
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Address> addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Order)
                .HasForeignKey(key => key.customer_id);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Customer)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(key => key.customer_id);
        }
    }
}
