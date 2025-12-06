using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SoccerSphere.Migrations
{
    /// <inheritdoc />
    public partial class update_context_with_more_players : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 1,
                columns: new[] { "Assists", "Goals", "MatchesPlayed", "Rating" },
                values: new object[] { 7, 6, 8, 8.1999999999999993 });

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "PlayerId", "Assists", "Country", "Goals", "MatchesPlayed", "PlayerName", "Rating", "TeamId" },
                values: new object[,]
                {
                    { 2, 7, "Spain", 6, 8, "Pedri", 8.1999999999999993, 1 },
                    { 3, 4, "Poland", 12, 10, "Robert Lewandowski", 8.5, 1 },
                    { 4, 5, "Spain", 3, 9, "Gavi", 7.9000000000000004, 1 },
                    { 5, 1, "Uruguay", 1, 9, "Ronald Araújo", 7.7999999999999998, 1 },
                    { 6, 0, "Germany", 0, 9, "Marc-André ter Stegen", 8.0999999999999996, 1 },
                    { 7, 6, "France", 14, 11, "Kylian Mbappé", 9.0, 2 },
                    { 8, 7, "Brazil", 8, 10, "Vinícius Júnior", 8.4000000000000004, 2 },
                    { 9, 5, "England", 10, 11, "Jude Bellingham", 8.6999999999999993, 2 },
                    { 10, 0, "Belgium", 0, 8, "Thibaut Courtois", 8.3000000000000007, 2 },
                    { 11, 2, "Austria", 2, 9, "David Alaba", 7.9000000000000004, 2 },
                    { 12, 3, "Norway", 15, 11, "Erling Haaland", 9.0999999999999996, 3 },
                    { 13, 6, "England", 7, 11, "Phil Foden", 8.5, 3 },
                    { 14, 7, "Portugal", 4, 10, "Bernardo Silva", 8.1999999999999993, 3 },
                    { 15, 0, "Portugal", 1, 10, "Rúben Dias", 7.7999999999999998, 3 },
                    { 16, 4, "England", 3, 9, "Jack Grealish", 7.9000000000000004, 3 },
                    { 17, 6, "Norway", 6, 10, "Martin Ødegaard", 8.4000000000000004, 4 },
                    { 18, 8, "England", 9, 11, "Bukayo Saka", 8.8000000000000007, 4 },
                    { 19, 4, "England", 2, 8, "Declan Rice", 6.7000000000000002, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "players",
                keyColumn: "PlayerId",
                keyValue: 1,
                columns: new[] { "Assists", "Goals", "MatchesPlayed", "Rating" },
                values: new object[] { 0, 0, 0, 0.0 });
        }
    }
}
