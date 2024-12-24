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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasKey(x => x.Id);
            modelBuilder.Entity<Player>().HasKey(x => x.Id);
            modelBuilder.Entity<Team>().HasKey(x => x.Id);

            modelBuilder.Entity<Player>().HasOne((x) => x.Team).WithMany((x) => x.players).HasForeignKey((x) => x.Team_id);
            modelBuilder.Entity<Match>().HasOne((x) => x.Team1).WithMany((x) => x.HomeMatches).HasForeignKey((x) => x.Team1_id);
            modelBuilder.Entity<Match>().HasOne((x) => x.Team2).WithMany((x) => x.AwayMatches).HasForeignKey((x) => x.Team2_id);
        }

    }
}
