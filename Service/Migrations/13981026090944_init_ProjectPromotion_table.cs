using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class init_ProjectPromotion_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectPromotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromotionBasicInfoId = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Score = table.Column<float>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    ProjectTypeOrPlan = table.Column<int>(nullable: true),
                    ProjectExecutiveName = table.Column<string>(nullable: true),
                    ProjectManagerName = table.Column<string>(nullable: true),
                    ExecutiveUnit = table.Column<string>(nullable: true),
                    ProjectType = table.Column<int>(nullable: true),
                    ProjectPeriod = table.Column<int>(nullable: false),
                    ProjectCost = table.Column<int>(nullable: false),
                    PersonnelCost = table.Column<int>(nullable: true),
                    PLF02File = table.Column<string>(nullable: true),
                    Assistance = table.Column<int>(nullable: true),
                    ParticipationPercentage = table.Column<float>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Documentation = table.Column<string>(nullable: true),
                    PLF05Form = table.Column<string>(nullable: true),
                    CooperationCertificate = table.Column<string>(nullable: true),
                    StepWeight = table.Column<float>(nullable: true),
                    ReportType = table.Column<int>(nullable: true),
                    JudgmentType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPromotion_PromotionBasicInfo_PromotionBasicInfoId",
                        column: x => x.PromotionBasicInfoId,
                        principalTable: "PromotionBasicInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    ScorePerRow = table.Column<float>(nullable: true),
                    ScorePerCase = table.Column<float>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPromotion_PromotionBasicInfoId",
                table: "ProjectPromotion",
                column: "PromotionBasicInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPromotion");

            migrationBuilder.DropTable(
                name: "Promotion");
        }
    }
}
