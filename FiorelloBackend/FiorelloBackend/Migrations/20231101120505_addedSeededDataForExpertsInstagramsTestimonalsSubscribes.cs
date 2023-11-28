using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloBackend.Migrations
{
    public partial class addedSeededDataForExpertsInstagramsTestimonalsSubscribes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Author", "Image", "Position", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "CRYSTAL BROOKS", "h3-team-img-1.png", "Florist", false },
                    { 2, "SHIRLEY HARRIS", "h3-team-img-2.png", "Manager", false },
                    { 3, "AMANDA WATKINS", "h3-team-img-4.png", "Florist", false },
                    { 4, "BEVERLY CLARK", "h3-team-img-3.png", "Florist", false }
                });

            migrationBuilder.InsertData(
                table: "Instagrams",
                columns: new[] { "Id", "Image", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "instagram1.jpg", false },
                    { 2, "instagram2.jpg", false },
                    { 3, "instagram3.jpg", false },
                    { 4, "instagram4.jpg", false },
                    { 5, "instagram5.jpg", false },
                    { 6, "instagram6.jpg", false },
                    { 7, "instagram7.jpg", false },
                    { 8, "instagram8.jpg", false }
                });

            migrationBuilder.InsertData(
                table: "Subscribes",
                columns: new[] { "Id", "Image", "SoftDeleted", "Title" },
                values: new object[] { 1, "h3-background-img.jpg", false, "Join The Colorful Bunch!" });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "About", "Author", "Image", "Position", "SoftDeleted" },
                values: new object[,]
                {
                    { 1, "Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus lingua.", "Anna Barnes", "testimonial-img-1.png", "Florist", false },
                    { 2, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget.", "Jasmine White", "testimonial-img-2.png", "Florist", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instagrams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subscribes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
