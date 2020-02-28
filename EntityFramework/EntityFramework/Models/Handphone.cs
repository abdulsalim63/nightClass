using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Models
{
    public class HandphoneContext : DbContext
    {
        // constructor
        public HandphoneContext(DbContextOptions<HandphoneContext> options) : base(options)
        {

        }
        public DbSet<Handphone> handphones { get; set; }
    }

    public class Handphone
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public int price { get; set; }
    }
}
