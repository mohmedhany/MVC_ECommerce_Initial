using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class edit_cartitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e110f952-c0ce-4a47-9a45-ba7f2d187091");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f16c67e8-44ad-45e0-b026-9ed9badfbc12");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ade001a-831f-443f-b3b2-1ad58ef9237a", "33ba8ff5-9b89-451e-a86b-b30052d4d342", "User", "user" },
                    { "d949448e-efa9-4e31-b3a2-8406d1267361", "d72b4094-b73d-4c9d-9e95-5bc06bec62f0", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ade001a-831f-443f-b3b2-1ad58ef9237a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d949448e-efa9-4e31-b3a2-8406d1267361");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e110f952-c0ce-4a47-9a45-ba7f2d187091", "2dd1f81e-2c7c-4def-b632-b1e2d2713a8e", "Admin", "admin" },
                    { "f16c67e8-44ad-45e0-b026-9ed9badfbc12", "afc95c3e-0f28-43ee-bbb1-b9e59cb476c5", "User", "user" }
                });
        }
    }
}
