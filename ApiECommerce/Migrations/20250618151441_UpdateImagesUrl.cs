using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiECommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImagesUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1550547660-d9450f859349?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1586190848861-99aa4a171e90?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1510626176961-4b532c216c48?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1572371242054-d1e6fac0f039?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1595006316746-3d470a6bbf4b?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1550547660-d9450f859349?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Cheeseburger Standard", "https://images.unsplash.com/photo-1606755962776-0d82a6bdc9d1?auto=format&fit=crop&w=400&h=300" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Cheese salad Standard", "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=400&h=300" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1586190848861-99aa4a171e90?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Cheeseburger, fries, soda", "https://images.unsplash.com/photo-1606755962776-0d82a6bdc9d1?auto=format&fit=crop&w=400&h=300" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Cheese salad, fries, soda", "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=400&h=300" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Natural meal with cheese", "https://images.unsplash.com/photo-1553621042-f6e147245754?auto=format&fit=crop&w=400&h=300" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1584270354949-1e4460a73f30?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1510626176961-4b532c216c48?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1604081162767-2ac79c030e66?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1600284677450-0609be27a4be?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1572371242054-d1e6fac0f039?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1587316745621-3757c7076f7e?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1571680797520-32d9c90911c6?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1588001403519-989f1f11f1c7?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1595006316746-3d470a6bbf4b?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1613145991415-bd12f7e6de26?auto=format&fit=crop&w=400&h=300");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "UrlImage",
                value: "https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=400&h=300");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?meal,food");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?combo-meal,fastfood");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?natural,vegetarian");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?drink,soda");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?juice,fruit");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?dessert,cake");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?burger");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Cheseburger Standard", "https://source.unsplash.com/400x300/?cheeseburger" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Chese salad Standard", "https://source.unsplash.com/400x300/?salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?burger,fries,cola");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Cheseburger, fries, soda", "https://source.unsplash.com/400x300/?cheeseburger,fries,drink" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Chese salad, fries, soda", "https://source.unsplash.com/400x300/?salad,fries,drink" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?vegetarian");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "UrlImage" },
                values: new object[] { "Natural meal with chese", "https://source.unsplash.com/400x300/?vegetarian,cheese" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?vegan");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?coca-cola");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?soda,guarana");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?pepsi");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?orange-juice");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?strawberry-juice");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?grape-juice");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?water,bottle");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?chocolate-cookies");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?vanilla-cookies");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "UrlImage",
                value: "https://source.unsplash.com/400x300/?cake,chocolate");
        }
    }
}
