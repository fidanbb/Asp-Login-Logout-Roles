using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloBackend.Migrations
{
    public partial class updateColumnValentineOpportunityInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValentineOpportunityInfos_ValentineOpportunities_ValentineOpportunityId1",
                table: "ValentineOpportunityInfos");

            migrationBuilder.DropIndex(
                name: "IX_ValentineOpportunityInfos_ValentineOpportunityId1",
                table: "ValentineOpportunityInfos");

            migrationBuilder.DropColumn(
                name: "ValentineOpportunityId1",
                table: "ValentineOpportunityInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ValentineOpportunityId",
                table: "ValentineOpportunityInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ValentineOpportunityInfos_ValentineOpportunityId",
                table: "ValentineOpportunityInfos",
                column: "ValentineOpportunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ValentineOpportunityInfos_ValentineOpportunities_ValentineOpportunityId",
                table: "ValentineOpportunityInfos",
                column: "ValentineOpportunityId",
                principalTable: "ValentineOpportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ValentineOpportunityInfos_ValentineOpportunities_ValentineOpportunityId",
                table: "ValentineOpportunityInfos");

            migrationBuilder.DropIndex(
                name: "IX_ValentineOpportunityInfos_ValentineOpportunityId",
                table: "ValentineOpportunityInfos");

            migrationBuilder.AlterColumn<string>(
                name: "ValentineOpportunityId",
                table: "ValentineOpportunityInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ValentineOpportunityId1",
                table: "ValentineOpportunityInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ValentineOpportunityInfos_ValentineOpportunityId1",
                table: "ValentineOpportunityInfos",
                column: "ValentineOpportunityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ValentineOpportunityInfos_ValentineOpportunities_ValentineOpportunityId1",
                table: "ValentineOpportunityInfos",
                column: "ValentineOpportunityId1",
                principalTable: "ValentineOpportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
