using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Models
{
    public class AccesoriesContext : DbContext
    {
        // constructor
        public AccesoriesContext(DbContextOptions<AccesoriesContext> options) : base(options)
        {
        }
        public DbSet<Accesories> accesories { get; set; }
    }

    public class Accesories
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
    }
}
