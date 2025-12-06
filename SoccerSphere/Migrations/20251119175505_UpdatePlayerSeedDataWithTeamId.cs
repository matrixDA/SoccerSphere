using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerSphere.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlayerSeedDataWithTeamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leagues");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "PlayerId", "Assists", "Country", "Goals", "MatchesPlayed", "PlayerName", "Rating", "TeamId" },
                values: new object[] { 1, 0, "Spain", 0, 0, "Pedri", 0.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_players_TeamId",
                table: "players",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_players_teams_TeamId",
                table: "players",
                column: "TeamId",
                principalTable: "teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_players_teams_TeamId",
                table: "players");

            migrationBuilder.DropIndex(
                name: "IX_players_TeamId",
                table: "players");

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Country",
                table: "players");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "players");

            migrationBuilder.CreateTable(
                name: "leagues",
                columns: table => new
                {
                    leagueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leagueContinent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    leagueCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    leagueName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leagues", x => x.leagueId);
                });
        }
    }
}
