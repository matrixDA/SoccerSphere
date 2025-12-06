using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerSphere.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Loss",
                table: "teams",
                newName: "Loses");

            migrationBuilder.UpdateData(
                table: "teams",
                keyColumn: "TeamId",
                keyValue: 2,
                columns: new[] { "Loses", "Revenue", "TeamName", "Wins" },
                values: new object[] { 3, 200000000m, "Real Madrid", 8 });

            migrationBuilder.UpdateData(
                table: "teams",
                keyColumn: "TeamId",
                keyValue: 3,
                columns: new[] { "Country", "Loses", "Revenue", "TeamName", "Wins" },
                values: new object[] { "England", 1, 150000000m, "Manchester City", 10 });

            migrationBuilder.UpdateData(
                table: "teams",
                keyColumn: "TeamId",
                keyValue: 4,
                columns: new[] { "Country", "Draws", "Loses", "Revenue", "TeamName" },
                values: new object[] { "England", 2, 1, 120000000m, "Arsenal" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Loses",
                table: "teams",
                newName: "Loss");

            migrationBuilder.UpdateData(
                table: "teams",
                keyColumn: "TeamId",
                keyValue: 2,
                columns: new[] { "Loss", "Revenue", "TeamName", "Wins" },
                values: new object[] { 2, 100000000m, "Barcelona", 9 });

            migrationBuilder.UpdateData(
                table: "teams",
                keyColumn: "TeamId",
                keyValue: 3,
                columns: new[] { "Country", "Loss", "Revenue", "TeamName", "Wins" },
                values: new object[] { "Spain", 2, 100000000m, "Barcelona", 9 });

            migrationBuilder.UpdateData(
                table: "teams",
                keyColumn: "TeamId",
                keyValue: 4,
                columns: new[] { "Country", "Draws", "Loss", "Revenue", "TeamName" },
                values: new object[] { "Spain", 1, 2, 100000000m, "Barcelona" });
        }
    }
}
