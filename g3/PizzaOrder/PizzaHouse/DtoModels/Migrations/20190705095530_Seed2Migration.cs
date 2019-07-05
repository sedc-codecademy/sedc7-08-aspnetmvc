using Microsoft.EntityFrameworkCore.Migrations;

namespace DtoModels.Migrations
{
    public partial class Seed2Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone" },
                values: new object[] { 1, "Skopje", "risto@gmail.com", "Risto", "risto", "+389111111" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone" },
                values: new object[] { 2, "Skopje", "martin@gmail.com", "Martin", "martin", "+389222222" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
