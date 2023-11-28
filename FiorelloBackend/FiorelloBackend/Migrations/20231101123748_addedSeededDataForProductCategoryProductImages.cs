using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloBackend.Migrations
{
    public partial class addedSeededDataForProductCategoryProductImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "POPULAR", false },
                    { 2, "WINTER", false },
                    { 3, "VARIOUS", false },
                    { 4, "EXOTIC", false },
                    { 5, "GREENS", false },
                    { 6, "CACTUSES", false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, 6, "Desc1", "Test1", 200m, false },
                    { 2, 4, "Desc2", "Test2", 300m, false },
                    { 3, 3, "Desc3", "Test3", 400m, false },
                    { 4, 1, "Desc4", "Test4", 500m, false },
                    { 5, 2, "Desc5", "Test5", 600m, false },
                    { 6, 2, "Desc6", "Test6", 700m, false },
                    { 7, 4, "Desc7", "Test7", 800m, false },
                    { 8, 5, "Desc8", "Test8", 900m, false },
                    { 9, 5, "Desc9", "Test9", 100m, false }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Image", "IsMain", "ProductId", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "shop-14-img.jpg", true, 1, false },
                    { 2, "shop-13-img.jpg", false, 1, false },
                    { 3, "shop-12-img.jpg", false, 1, false },
                    { 4, "shop-13-img.jpg", false, 2, false },
                    { 5, "shop-14-img.jpg", true, 2, false },
                    { 6, "shop-11-img.jpg", true, 3, false },
                    { 7, "shop-10-img.jpg", false, 3, false },
                    { 8, "shop-9-img.jpg", false, 3, false },
                    { 9, "shop-11-img.jpg", true, 4, false },
                    { 10, "shop-12-img.jpg", false, 4, false },
                    { 11, "shop-10-img.jpg", true, 5, false },
                    { 12, "shop-13-img.jpg", false, 5, false },
                    { 13, "shop-9-img.jpg", true, 6, false },
                    { 14, "shop-14-img.jpg", false, 6, false },
                    { 15, "shop-8-img.jpg", true, 7, false },
                    { 16, "shop-11-img.jpg", false, 7, false },
                    { 17, "shop-9-img.jpg", false, 7, false },
                    { 18, "shop-7-img.jpg", true, 8, false },
                    { 19, "shop-10-img.jpg", false, 8, false },
                    { 20, "shop-14-img.jpg", true, 9, false },
                    { 21, "shop-8-img.jpg", false, 9, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
