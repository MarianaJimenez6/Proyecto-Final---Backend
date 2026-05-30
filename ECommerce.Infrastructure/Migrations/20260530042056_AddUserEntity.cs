using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("21dbb3c4-00b7-42ed-aa0a-94b50ef47a9d"), new Guid("337bbf57-e7b7-43ea-9982-3af938953a7a"), new DateTime(2026, 5, 30, 4, 20, 55, 879, DateTimeKind.Utc).AddTicks(5679), "Laptop gaming i7", "Laptop Dell", 1200.99m, 15 },
                    { new Guid("66bc6484-ab57-42dd-bbf0-6e5a4515548c"), new Guid("d16bc36d-e5e9-4f0a-b38a-8a365c158d0c"), new DateTime(2026, 5, 30, 4, 20, 55, 879, DateTimeKind.Utc).AddTicks(5701), "Casco integral", "Casco Moto", 85.50m, 25 },
                    { new Guid("d4d0143e-c68f-401d-b3a6-b3106cc618e3"), new Guid("1b3693f0-4237-4aec-9094-51e782045574"), new DateTime(2026, 5, 30, 4, 20, 55, 879, DateTimeKind.Utc).AddTicks(5685), "Celular Apple", "Iphone 15", 899.99m, 8 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PasswordHash", "Role" },
                values: new object[] { new Guid("14a6e9d0-6c83-44fa-9019-60ebf5f525ae"), new DateTime(2026, 5, 30, 4, 20, 55, 879, DateTimeKind.Utc).AddTicks(5925), "admin@ecommerce.com", "Admin", "123456", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21dbb3c4-00b7-42ed-aa0a-94b50ef47a9d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("66bc6484-ab57-42dd-bbf0-6e5a4515548c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4d0143e-c68f-401d-b3a6-b3106cc618e3"));

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
    }
}
