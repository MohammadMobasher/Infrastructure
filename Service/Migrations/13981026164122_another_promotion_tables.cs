using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class another_promotion_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookPromotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromotionBasicInfoId = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    FestivalType = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    PlanTitle = table.Column<string>(nullable: true),
                    RankEarned = table.Column<int>(nullable: true),
                    ParticipationPercentage = table.Column<float>(nullable: true),
                    Documentation = table.Column<string>(nullable: true),
                    PersonCount = table.Column<byte>(nullable: true),
                    PersonPosition = table.Column<byte>(nullable: true),
                    BookType = table.Column<int>(nullable: true),
                    PublisherTitle = table.Column<string>(nullable: true),
                    Published = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPromotion_PromotionBasicInfo_PromotionBasicInfoId",
                        column: x => x.PromotionBasicInfoId,
                        principalTable: "PromotionBasicInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalActivityPromotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromotionBasicInfoId = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    LessonTitle = table.Column<string>(nullable: true),
                    LessonUnit = table.Column<int>(nullable: true),
                    AcademicYear = table.Column<int>(nullable: true),
                    Term = table.Column<int>(nullable: true),
                    Documentation = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    EventPlace = table.Column<string>(nullable: true),
                    PeriodTime = table.Column<int>(nullable: true),
                    AssemblyTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalActivityPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalActivityPromotion_PromotionBasicInfo_PromotionBasicInfoId",
                        column: x => x.PromotionBasicInfoId,
                        principalTable: "PromotionBasicInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostPromotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromotionBasicInfoId = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CorporateResponsibilityTime = table.Column<int>(nullable: true),
                    Documentation = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    ContributionShare = table.Column<float>(nullable: true),
                    ParticipationTime = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostPromotion_PromotionBasicInfo_PromotionBasicInfoId",
                        column: x => x.PromotionBasicInfoId,
                        principalTable: "PromotionBasicInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPromotion_PromotionBasicInfoId",
                table: "BookPromotion",
                column: "PromotionBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalActivityPromotion_PromotionBasicInfoId",
                table: "EducationalActivityPromotion",
                column: "PromotionBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPromotion_PromotionBasicInfoId",
                table: "PostPromotion",
                column: "PromotionBasicInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPromotion");

            migrationBuilder.DropTable(
                name: "EducationalActivityPromotion");

            migrationBuilder.DropTable(
                name: "PostPromotion");
        }
    }
}
