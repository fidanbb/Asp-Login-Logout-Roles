using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloBackend.Migrations
{
    public partial class addedSeededDataForValentineOpportunityAndOpportunityInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ValentineOpportunities",
                columns: new[] { "Id", "Description", "SoftDeleted", "Title", "VideoIcon", "VideoImage" },
                values: new object[] { 2, "Where flowers are our inspiration to create lasting memories. Whatever the occasion...", false, "<h1>Suprise Your <span>Valentine!</span> Let us arrange a smile.</h1>", "fas fa-play fa-lg", "h3-video-img.jpg" });

            migrationBuilder.InsertData(
                table: "ValentineOpportunityInfos",
                columns: new[] { "Id", "Icon", "Name", "SoftDeleted", "ValentineOpportunityId" },
                values: new object[] { 1, "h1-custom-icon.png", "Hand picked just for you.", false, 2 });

            migrationBuilder.InsertData(
                table: "ValentineOpportunityInfos",
                columns: new[] { "Id", "Icon", "Name", "SoftDeleted", "ValentineOpportunityId" },
                values: new object[] { 2, "h1-custom-icon.png", "Unique flower arrangements", false, 2 });

            migrationBuilder.InsertData(
                table: "ValentineOpportunityInfos",
                columns: new[] { "Id", "Icon", "Name", "SoftDeleted", "ValentineOpportunityId" },
                values: new object[] { 3, "h1-custom-icon.png", "Best way to say you care.", false, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ValentineOpportunityInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ValentineOpportunityInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ValentineOpportunityInfos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ValentineOpportunities",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
