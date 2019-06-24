using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaHut.Migrations
{
    public partial class PizzaTypeRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PizzaTypes",
                columns: new[] { "ID", "Description", "Name", "Photo" },
                values: new object[] { 1, "dough, ham, mashrums", "Capri", null });

            migrationBuilder.InsertData(
                table: "PizzaTypes",
                columns: new[] { "ID", "Description", "Name", "Photo" },
                values: new object[] { 2, "dough, cheese, mashrums", "Quatro", null });

            migrationBuilder.InsertData(
                table: "PizzaTypes",
                columns: new[] { "ID", "Description", "Name", "Photo" },
                values: new object[] { 3, "dough, vegetables, mashrums", "Vege", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PizzaTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PizzaTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PizzaTypes",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
