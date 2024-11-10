using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class newssssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c252594c-0ada-499e-8279-81994134e6ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd58e358-1810-42ca-b10c-ca647d3f559f");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Shipping",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1aa4eb0-2bec-403f-b663-b5ee9d0d6ad5", "8050e6c6-71fd-413e-b133-25297874530c", "Admin", "admin" },
                    { "cff4a873-33f2-4d17-a059-36cde909393f", "f9bfb097-4cbd-43a0-9aed-c8438912cd88", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1aa4eb0-2bec-403f-b663-b5ee9d0d6ad5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cff4a873-33f2-4d17-a059-36cde909393f");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Shipping",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c252594c-0ada-499e-8279-81994134e6ac", "dfbf31de-a247-447e-9e23-2b8a03759c54", "Admin", "admin" },
                    { "dd58e358-1810-42ca-b10c-ca647d3f559f", "01168a25-6258-4e96-9f47-f9e4a53e1d06", "User", "user" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
