using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EntityFramework.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        public DbSet<Customer> customers { get; set; }
    }

    public class Customer
    {
        [JsonProperty("customer_id")]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}
