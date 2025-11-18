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
                new Team {TeamId=1, TeamName = "Barcelona", Revenue = 100000000, Country = "Spain", Wins = 9, Loses = 2, Draws = 1 },
                new Team { TeamId = 2, TeamName = "Real Madrid", Revenue = 200000000, Country = "Spain", Wins = 8, Loses = 3, Draws = 1 },
                new Team { TeamId = 3, TeamName = "Manchester City", Revenue = 150000000, Country = "England", Wins = 10, Loses = 1, Draws = 1 },
                new Team { TeamId = 4, TeamName = "Arsenal", Revenue = 120000000, Country = "England", Wins = 9, Loses = 1, Draws = 2 }
                );
        }
    }
}