using Microsoft.EntityFrameworkCore;
namespace SoccerSphere.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options) { }
        public DbSet<Team> teams { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<League> leagues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team {TeamId=1, TeamName = "Barcelona", Revenue = 100000000, Country = "Spain", Wins = 9, Loss = 2, Draws = 1 },
                new Team { TeamId = 2, TeamName = "Barcelona", Revenue = 100000000, Country = "Spain", Wins = 9, Loss = 2, Draws = 1 },
                new Team { TeamId = 3, TeamName = "Barcelona", Revenue = 100000000, Country = "Spain", Wins = 9, Loss = 2, Draws = 1 },
                new Team { TeamId = 4, TeamName = "Barcelona", Revenue = 100000000, Country = "Spain", Wins = 9, Loss = 2, Draws = 1 }
                );

        }
    }
}