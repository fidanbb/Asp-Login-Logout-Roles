using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiorelloBackend.Migrations
{
    public partial class createValentineOpportunityAndValentineOpportunityInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ValentineOpportunities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValentineOpportunities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValentineOpportunityInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValentineOpportunityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValentineOpportunityId1 = table.Column<int>(type: "int", nullable: false),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValentineOpportunityInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValentineOpportunityInfos_ValentineOpportunities_ValentineOpportunityId1",
                        column: x => x.ValentineOpportunityId1,
                        principalTable: "ValentineOpportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValentineOpportunityInfos_ValentineOpportunityId1",
                table: "ValentineOpportunityInfos",
                column: "ValentineOpportunityId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValentineOpportunityInfos");

            migrationBuilder.DropTable(
                name: "ValentineOpportunities");
        }
    }
}
