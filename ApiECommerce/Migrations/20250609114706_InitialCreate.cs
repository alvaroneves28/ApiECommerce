using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiECommerce.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Popular = table.Column<bool>(type: "bit", nullable: false),
                    MostSold = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UrlImage" },
                values: new object[,]
                {
                    { 1, "Meals", "https://source.unsplash.com/400x300/?meal,food" },
                    { 2, "Combo Meals", "https://source.unsplash.com/400x300/?combo-meal,fastfood" },
                    { 3, "Naturals", "https://source.unsplash.com/400x300/?natural,vegetarian" },
                    { 4, "Drinks", "https://source.unsplash.com/400x300/?drink,soda" },
                    { 5, "Juices", "https://source.unsplash.com/400x300/?juice,fruit" },
                    { 6, "Desserts", "https://source.unsplash.com/400x300/?dessert,cake" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CategoryId", "Detail", "MostSold", "Name", "Popular", "Price", "Stock", "UrlImage" },
                values: new object[,]
                {
                    { 1, true, 1, "Classic hamburger", true, "Hamburger Standard", true, 5.99m, 50, "https://source.unsplash.com/400x300/?burger" },
                    { 2, true, 1, "Hamburger with cheese", false, "Cheseburger Standard", true, 6.49m, 45, "https://source.unsplash.com/400x300/?cheeseburger" },
                    { 3, true, 1, "Salad with cheese", false, "Chese salad Standard", false, 5.29m, 30, "https://source.unsplash.com/400x300/?salad" },
                    { 4, true, 2, "Combo meal with hamburger", true, "Hamburger, fries, soda", true, 9.99m, 40, "https://source.unsplash.com/400x300/?burger,fries,cola" },
                    { 5, true, 2, "Combo meal with cheeseburger", false, "Cheseburger, fries, soda", true, 10.49m, 35, "https://source.unsplash.com/400x300/?cheeseburger,fries,drink" },
                    { 6, true, 2, "Combo meal with salad", false, "Chese salad, fries, soda", false, 8.99m, 25, "https://source.unsplash.com/400x300/?salad,fries,drink" },
                    { 7, true, 3, "Vegetarian meal", false, "Natural meal with leafs", true, 7.99m, 20, "https://source.unsplash.com/400x300/?vegetarian" },
                    { 8, true, 3, "Vegetarian meal with cheese", false, "Natural meal with chese", false, 8.49m, 15, "https://source.unsplash.com/400x300/?vegetarian,cheese" },
                    { 9, true, 3, "Fully vegan option", false, "Vegan", false, 8.99m, 10, "https://source.unsplash.com/400x300/?vegan" },
                    { 10, true, 4, "Cold Coca-Cola can", true, "Coca-cola", true, 1.50m, 100, "https://source.unsplash.com/400x300/?coca-cola" },
                    { 11, true, 4, "Refreshing Brazilian soda", false, "Guaraná", false, 1.40m, 80, "https://source.unsplash.com/400x300/?soda,guarana" },
                    { 12, true, 4, "Cold Pepsi can", false, "Pepsi", false, 1.50m, 90, "https://source.unsplash.com/400x300/?pepsi" },
                    { 13, true, 5, "Fresh orange juice", false, "Orange juice", true, 2.00m, 50, "https://source.unsplash.com/400x300/?orange-juice" },
                    { 14, true, 5, "Fresh strawberry juice", false, "Strawberry juice", false, 2.20m, 45, "https://source.unsplash.com/400x300/?strawberry-juice" },
                    { 15, true, 5, "Fresh grape juice", false, "Grape Juice", false, 2.10m, 40, "https://source.unsplash.com/400x300/?grape-juice" },
                    { 16, true, 5, "Mineral water", false, "Water", false, 1.00m, 100, "https://source.unsplash.com/400x300/?water,bottle" },
                    { 17, true, 6, "Chocolate chip cookies", false, "Chocolate cookies", true, 2.50m, 30, "https://source.unsplash.com/400x300/?chocolate-cookies" },
                    { 18, true, 6, "Vanilla flavored cookies", false, "Vanilla cookies", false, 2.40m, 28, "https://source.unsplash.com/400x300/?vanilla-cookies" },
                    { 19, true, 6, "Chocolate swiss roll cake", true, "Swiss cake", true, 3.00m, 25, "https://source.unsplash.com/400x300/?cake,chocolate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_OrderId",
                table: "BasketItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
