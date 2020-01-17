using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class init_ArticlePromotion_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticlePromotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromotionBasicInfoId = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: true),
                    ArticleType = table.Column<int>(nullable: true),
                    ArticleDOI = table.Column<string>(nullable: true),
                    ArticleTitle = table.Column<string>(nullable: true),
                    JournalTitle = table.Column<string>(nullable: true),
                    ArticleLanguage = table.Column<int>(nullable: true),
                    ArticleIndex = table.Column<int>(nullable: true),
                    WritersCount = table.Column<byte>(nullable: true),
                    WriterPosition = table.Column<byte>(nullable: true),
                    AcceptDate = table.Column<DateTime>(nullable: true),
                    FirstPageFile = table.Column<string>(nullable: true),
                    CertificationFile = table.Column<string>(nullable: true),
                    ConferenceType = table.Column<int>(nullable: true),
                    SetPeriod = table.Column<int>(nullable: true),
                    UniversityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlePromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlePromotion_PromotionBasicInfo_PromotionBasicInfoId",
                        column: x => x.PromotionBasicInfoId,
                        principalTable: "PromotionBasicInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePromotion_PromotionBasicInfoId",
                table: "ArticlePromotion",
                column: "PromotionBasicInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticlePromotion");
        }
    }
}
