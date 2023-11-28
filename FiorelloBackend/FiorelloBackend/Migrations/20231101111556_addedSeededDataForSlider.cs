using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloBackend.Migrations
{
    public partial class addedSeededDataForSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Img", "SoftDeleted" },
                values: new object[] { 1, "h3-slider-background.jpg", false });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Img", "SoftDeleted" },
                values: new object[] { 2, "h3-slider-background-2.jpg", false });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Img", "SoftDeleted" },
                values: new object[] { 3, "h3-slider-background-3.jpg", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
