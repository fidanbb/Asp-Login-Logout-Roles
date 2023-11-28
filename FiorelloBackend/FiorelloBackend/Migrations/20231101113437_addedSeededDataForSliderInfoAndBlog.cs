using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloBackend.Migrations
{
    public partial class addedSeededDataForSliderInfoAndBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedDate", "Description", "Image", "SoftDeleted", "Title" },
                values: new object[,]
                {
                    { 1, null, "1Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-1.jpg", false, "Flower Power" },
                    { 2, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "2Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-2.jpg", false, "Local Florists" },
                    { 3, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "3Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-3.jpg", false, "Flower Beauty" },
                    { 4, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4Class aptent taciti sociosqu ad litora torquent per conubia nostra, per", "blog-feature-img-1.jpg", false, "New Data" }
                });

            migrationBuilder.InsertData(
                table: "SliderInfos",
                columns: new[] { "Id", "Description", "SignImg", "SoftDeleted", "Title" },
                values: new object[] { 1, "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will make it special cursus a sit amet mauris.", "h2-sign-img.png", false, "<h1>Send <span>flowers </span>  like</h1> <h1>you mean it</h1>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SliderInfos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
