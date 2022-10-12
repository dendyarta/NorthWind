using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Persistence.Migrations.Northwind
{
    public partial class AddRoleToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ce2a3af-66f2-45f6-9a63-c15a349be228", "b8275e05-a718-41f9-8946-555c932ecd02", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81bea67b-1cca-447b-b8a7-abb737600f8c", "635fea15-a67c-4475-bc77-c8935224e171", "Administrartor", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ce2a3af-66f2-45f6-9a63-c15a349be228");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81bea67b-1cca-447b-b8a7-abb737600f8c");
        }
    }
}
