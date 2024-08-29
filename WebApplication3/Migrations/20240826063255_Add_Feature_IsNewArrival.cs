using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Add_Feature_IsNewArrival : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ade001a-831f-443f-b3b2-1ad58ef9237a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d949448e-efa9-4e31-b3a2-8406d1267361");

            migrationBuilder.AddColumn<bool>(
                name: "IsNewArrival",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c41746d-c10b-4eed-93d3-077a031829ac", "28991fbc-a5a9-48e4-a3ae-69a63adf19ae", "Admin", "admin" },
                    { "9fee3bab-4878-4033-8ad6-120a8deb605b", "4323d2ad-16e5-493a-b154-716853e9584c", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c41746d-c10b-4eed-93d3-077a031829ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fee3bab-4878-4033-8ad6-120a8deb605b");

            migrationBuilder.DropColumn(
                name: "IsNewArrival",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ade001a-831f-443f-b3b2-1ad58ef9237a", "33ba8ff5-9b89-451e-a86b-b30052d4d342", "User", "user" },
                    { "d949448e-efa9-4e31-b3a2-8406d1267361", "d72b4094-b73d-4c9d-9e95-5bc06bec62f0", "Admin", "admin" }
                });
        }
    }
}
