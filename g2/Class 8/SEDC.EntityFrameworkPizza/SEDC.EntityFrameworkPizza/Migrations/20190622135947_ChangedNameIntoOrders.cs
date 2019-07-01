using Microsoft.EntityFrameworkCore.Migrations;

namespace SEDC.EntityFrameworkPizza.Migrations
{
    public partial class ChangedNameIntoOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Dejan Jovanov");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Martin Panovski");
        }
    }
}
