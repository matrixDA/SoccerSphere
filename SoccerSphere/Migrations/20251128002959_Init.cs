using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoccerSphere.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Loses = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_players_positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_players_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "PositionId", "PositionName" },
                values: new object[,]
                {
                    { 1, "Forward" },
                    { 2, "Midfielder" },
                    { 3, "Defender" },
                    { 4, "Goalkeeper" }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "TeamId", "Country", "Draws", "Loses", "Revenue", "TeamName", "Wins" },
                values: new object[,]
                {
                    { 1, "Spain", 1, 2, 100000000m, "Barcelona", 9 },
                    { 2, "Spain", 1, 3, 200000000m, "Real Madrid", 8 },
                    { 3, "England", 1, 1, 150000000m, "Manchester City", 10 },
                    { 4, "England", 2, 1, 120000000m, "Arsenal", 9 }
                });

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "PlayerId", "Assists", "Country", "Goals", "MatchesPlayed", "PlayerName", "PositionId", "Rating", "TeamId" },
                values: new object[,]
                {
                    { 1, 7, "Spain", 6, 8, "Pedri", 2, 8.1999999999999993, 1 },
                    { 3, 4, "Poland", 12, 10, "Robert Lewandowski", 1, 8.5, 1 },
                    { 4, 5, "Spain", 3, 9, "Gavi", 2, 7.9000000000000004, 1 },
                    { 5, 1, "Uruguay", 1, 9, "Ronald Araújo", 3, 7.7999999999999998, 1 },
                    { 6, 0, "Germany", 0, 9, "Marc-André ter Stegen", 4, 8.0999999999999996, 1 },
                    { 7, 6, "France", 14, 11, "Kylian Mbappé", 1, 9.0, 2 },
                    { 8, 7, "Brazil", 8, 10, "Vinícius Júnior", 1, 8.4000000000000004, 2 },
                    { 9, 5, "England", 10, 11, "Jude Bellingham", 2, 8.6999999999999993, 2 },
                    { 10, 0, "Belgium", 0, 8, "Thibaut Courtois", 4, 8.3000000000000007, 2 },
                    { 11, 2, "Austria", 2, 9, "David Alaba", 3, 7.9000000000000004, 2 },
                    { 12, 3, "Norway", 15, 11, "Erling Haaland", 1, 9.0999999999999996, 3 },
                    { 13, 6, "England", 7, 11, "Phil Foden", 2, 8.5, 3 },
                    { 14, 7, "Portugal", 4, 10, "Bernardo Silva", 2, 8.1999999999999993, 3 },
                    { 15, 0, "Portugal", 1, 10, "Rúben Dias", 3, 7.7999999999999998, 3 },
                    { 16, 4, "England", 3, 9, "Jack Grealish", 2, 7.9000000000000004, 3 },
                    { 17, 6, "Norway", 6, 10, "Martin Ødegaard", 2, 8.4000000000000004, 4 },
                    { 18, 8, "England", 9, 11, "Bukayo Saka", 1, 8.8000000000000007, 4 },
                    { 19, 4, "England", 2, 8, "Declan Rice", 2, 6.7000000000000002, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_PositionId",
                table: "players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_players_TeamId",
                table: "players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
