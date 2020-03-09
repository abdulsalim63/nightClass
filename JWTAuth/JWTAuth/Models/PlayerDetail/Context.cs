using System;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Models.PlayerDetail
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }
        public DbSet<Player> players { get; set; }
    }
}
