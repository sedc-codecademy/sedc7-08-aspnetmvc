using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Trainers");

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Sarry" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Emery" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "TrainerId" },
                values: new object[] { 1, "Chelsea", 1 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "TrainerId" },
                values: new object[] { 2, "Arsenal", 2 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, "Keppa", 1 },
                    { 2, "Luiz", 1 },
                    { 3, "Hazard", 1 },
                    { 4, "Cheh", 2 },
                    { 5, "Mustafi", 2 },
                    { 6, "Aubamejang", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Trainers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
