using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class add_Identity_Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e110f952-c0ce-4a47-9a45-ba7f2d187091", "2dd1f81e-2c7c-4def-b632-b1e2d2713a8e", "Admin", "admin" },
                    { "f16c67e8-44ad-45e0-b026-9ed9badfbc12", "afc95c3e-0f28-43ee-bbb1-b9e59cb476c5", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e110f952-c0ce-4a47-9a45-ba7f2d187091");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f16c67e8-44ad-45e0-b026-9ed9badfbc12");
        }
    }
}
