using ApiProject_Joachim_Adomako.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject_Joachim_Adomako.Data
{
    public class SportDbContext : DbContext
    {
        public SportDbContext(DbContextOptions<SportDbContext> options): base(options)
        {}
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> players { get; set; }

    }
}
