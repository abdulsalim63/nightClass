using System;
using Microsoft.EntityFrameworkCore;

namespace Trial.Models
{
    public class hallOfFameContext : DbContext
    {
        public hallOfFameContext(DbContextOptions<hallOfFameContext> options)
            : base(options)
        {
        }

        public DbSet<hallOfFame> hallOfFames { get; set; }
    }

    public class hallOfFame
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Title { get; set; }
    }
}
