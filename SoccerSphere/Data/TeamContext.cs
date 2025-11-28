using Microsoft.EntityFrameworkCore;
using SoccerSphere.Models;
namespace SoccerSphere.Data
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options)
            : base(options) { }
        public DbSet<Team> teams { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Position> positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, TeamName = "Barcelona", Revenue = 100000000, Country = "Spain", Wins = 9, Loses = 2, Draws = 1 },
                new Team { TeamId = 2, TeamName = "Real Madrid", Revenue = 200000000, Country = "Spain", Wins = 8, Loses = 3, Draws = 1 },
                new Team { TeamId = 3, TeamName = "Manchester City", Revenue = 150000000, Country = "England", Wins = 10, Loses = 1, Draws = 1 },
                new Team { TeamId = 4, TeamName = "Arsenal", Revenue = 120000000, Country = "England", Wins = 9, Loses = 1, Draws = 2 }
                );

            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 1, PositionName = "Forward" },
                new Position { PositionId = 2, PositionName = "Midfielder" },
                new Position { PositionId = 3, PositionName = "Defender" },
                new Position { PositionId = 4, PositionName = "Goalkeeper" }
);

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    PlayerId = 1,
                    PlayerName = "Pedri",
                    Country = "Spain",
                    TeamId = 1 ,
                    Goals = 6,
                    Assists = 7,
                    MatchesPlayed = 8,
                    Rating = 8.2,
                    PositionId = 2
                },
                new Player
                {
                    PlayerId = 3,
                    PlayerName = "Robert Lewandowski",
                    Country = "Poland",
                    TeamId = 1,
                    Goals = 12,
                    Assists = 4,
                    MatchesPlayed = 10,
                    Rating = 8.5,
                    PositionId = 1
                },
                new Player
                {
                    PlayerId = 4,
                    PlayerName = "Gavi",
                    Country = "Spain",
                    TeamId = 1,
                    Goals = 3,
                    Assists = 5,
                    MatchesPlayed = 9,
                    Rating = 7.9,
                    PositionId = 2
                },
                new Player
                {
                    PlayerId = 5,
                    PlayerName = "Ronald Araújo",
                    Country = "Uruguay",
                    TeamId = 1,
                    Goals = 1,
                    Assists = 1,
                    MatchesPlayed = 9,
                    Rating = 7.8,
                    PositionId = 3
                },
                new Player
                {
                    PlayerId = 6,
                    PlayerName = "Marc-André ter Stegen",
                    Country = "Germany",
                    TeamId = 1,
                    Goals = 0,
                    Assists = 0,
                    MatchesPlayed = 9,
                    Rating = 8.1,
                    PositionId = 4
                },
                new Player
                {
                    PlayerId = 7,
                    PlayerName = "Kylian Mbappé",
                    Country = "France",
                    TeamId = 2,
                    Goals = 14,
                    Assists = 6,
                    MatchesPlayed = 11,
                    Rating = 9.0,
                    PositionId = 1

                },
                new Player
                {
                    PlayerId = 8,
                    PlayerName = "Vinícius Júnior",
                    Country = "Brazil",
                    TeamId = 2,
                    Goals = 8,
                    Assists = 7,
                    MatchesPlayed = 10,
                    Rating = 8.4,
                    PositionId = 1
                },
                new Player
                {
                    PlayerId = 9,
                    PlayerName = "Jude Bellingham",
                    Country = "England",
                    TeamId = 2,
                    Goals = 10,
                    Assists = 5,
                    MatchesPlayed = 11,
                    Rating = 8.7,
                    PositionId = 2

                },
                new Player
                {
                    PlayerId = 10,
                    PlayerName = "Thibaut Courtois",
                    Country = "Belgium",
                    TeamId = 2,
                    Goals = 0,
                    Assists = 0,
                    MatchesPlayed = 8,
                    Rating = 8.3,
                    PositionId = 4
                },
                new Player
                {
                    PlayerId = 11,
                    PlayerName = "David Alaba",
                    Country = "Austria",
                    TeamId = 2,
                    Goals = 2,
                    Assists = 2,
                    MatchesPlayed = 9,
                    Rating = 7.9,
                    PositionId = 3
                },
                new Player
                {
                    PlayerId = 12,
                    PlayerName = "Erling Haaland",
                    Country = "Norway",
                    TeamId = 3,
                    Goals = 15,
                    Assists = 3,
                    MatchesPlayed = 11,
                    Rating = 9.1,
                    PositionId = 1
                },
                new Player
                {
                    PlayerId = 13,
                    PlayerName = "Phil Foden",
                    Country = "England",
                    TeamId = 3,
                    Goals = 7,
                    Assists = 6,
                    MatchesPlayed = 11,
                    Rating = 8.5,
                    PositionId = 2
                },
                new Player
                {
                    PlayerId = 14,
                    PlayerName = "Bernardo Silva",
                    Country = "Portugal",
                    TeamId = 3,
                    Goals = 4,
                    Assists = 7,
                    MatchesPlayed = 10,
                    Rating = 8.2,
                    PositionId = 2
                },
                new Player
                {
                    PlayerId = 15,
                    PlayerName = "Rúben Dias",
                    Country = "Portugal",
                    TeamId = 3,
                    Goals = 1,
                    Assists = 0,
                    MatchesPlayed = 10,
                    Rating = 7.8,
                    PositionId = 3
                },
                new Player
                {
                    PlayerId = 16,
                    PlayerName = "Jack Grealish",
                    Country = "England",
                    TeamId = 3,
                    Goals = 3,
                    Assists = 4,
                    MatchesPlayed = 9,
                    Rating = 7.9,
                    PositionId = 2
                },
                new Player
                {
                    PlayerId = 17,
                    PlayerName = "Martin Ødegaard",
                    Country = "Norway",
                    TeamId = 4,
                    Goals = 6,
                    Assists = 6,
                    MatchesPlayed = 10,
                    Rating = 8.4,
                    PositionId = 2
                },
                new Player
                {
                    PlayerId = 18,
                    PlayerName = "Bukayo Saka",
                    Country = "England",
                    TeamId = 4,
                    Goals = 9,
                    Assists = 8,
                    MatchesPlayed = 11,
                    Rating = 8.8,
                    PositionId = 1
                },
                new Player
                {
                    PlayerId = 19,
                    PlayerName = "Declan Rice",
                    Country = "England",
                    TeamId = 4,
                    Goals = 2,
                    Assists = 4,
                    MatchesPlayed = 8,
                    Rating = 6.7,
                    PositionId = 2
                }
            );

        }
    }
}