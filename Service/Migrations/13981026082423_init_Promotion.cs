using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class init_Promotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mohammadTest");

            migrationBuilder.CreateTable(
                name: "BankAnnualPromotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAnnualPromotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionBasicInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    StartToWork = table.Column<DateTime>(nullable: false),
                    DeservedLastGrade = table.Column<int>(nullable: false),
                    SacrificeLastGrade = table.Column<int>(nullable: false),
                    IncentivesLastGrade = table.Column<int>(nullable: false),
                    SentenceFile = table.Column<string>(nullable: true),
                    WorkingHoursFile = table.Column<string>(nullable: true),
                    RoutineStep = table.Column<int>(nullable: false),
                    RoutineIsFlown = table.Column<bool>(nullable: false),
                    RoutineIsDone = table.Column<bool>(nullable: false),
                    RoutineFlownDate = table.Column<DateTime>(nullable: true),
                    RoutineStepChangeDate = table.Column<DateTime>(nullable: true),
                    RoutineIsSucceeded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionBasicInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionBasicInfo_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionBasicInfo_UserId",
                table: "PromotionBasicInfo",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAnnualPromotion");

            migrationBuilder.DropTable(
                name: "PromotionBasicInfo");

            migrationBuilder.CreateTable(
                name: "mohammadTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mohammadTest", x => x.Id);
                });
        }
    }
}
