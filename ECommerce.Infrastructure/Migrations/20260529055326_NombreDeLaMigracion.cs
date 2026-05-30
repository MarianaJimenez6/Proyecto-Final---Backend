using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("8036167c-c2d5-4301-9f68-bf2fb0467a4e"), new Guid("9975b4a9-53e8-4dc7-9a18-a2231caff5d1"), new DateTime(2026, 5, 29, 5, 53, 25, 297, DateTimeKind.Utc).AddTicks(3290), "Celular Apple", "Iphone 15", 899.99m, 8 },
                    { new Guid("b24e0f7f-9877-42b6-a769-0327d02adf08"), new Guid("6473a65c-1bd6-45e6-bf55-89a290671d4b"), new DateTime(2026, 5, 29, 5, 53, 25, 297, DateTimeKind.Utc).AddTicks(3286), "Laptop gaming i7", "Laptop Dell", 1200.99m, 15 },
                    { new Guid("b9a444e6-16b9-44c4-8d08-26c0f89bffdc"), new Guid("74d3ef0e-6020-4181-92ce-dc52277abef1"), new DateTime(2026, 5, 29, 5, 53, 25, 297, DateTimeKind.Utc).AddTicks(3293), "Casco integral", "Casco Moto", 85.50m, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8036167c-c2d5-4301-9f68-bf2fb0467a4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b24e0f7f-9877-42b6-a769-0327d02adf08"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9a444e6-16b9-44c4-8d08-26c0f89bffdc"));
        }
    }
}
