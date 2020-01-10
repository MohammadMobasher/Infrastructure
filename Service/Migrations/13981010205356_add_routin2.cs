using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_routin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routine2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    TableName = table.Column<string>(maxLength: 1024, nullable: true),
                    PkColumnName = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routine2Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutineId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    CreatorUserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    ToStep = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Action = table.Column<string>(maxLength: 1024, nullable: true),
                    RoutineRoleTitle = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routine2Log_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routine2Log_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notice2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<int>(nullable: true),
                    ToUserId = table.Column<int>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    RoutineId = table.Column<int>(nullable: true),
                    EntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notice2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notice2_AspNetUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notice2_Routine2_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routine2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notice2_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routine2Action",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutineId = table.Column<int>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    Action = table.Column<string>(maxLength: 32, nullable: true),
                    Title = table.Column<string>(maxLength: 2048, nullable: false),
                    Icon = table.Column<string>(maxLength: 64, nullable: true),
                    Color = table.Column<string>(maxLength: 64, nullable: true),
                    IsDescriptionRequired = table.Column<bool>(nullable: false),
                    ShouldHideDescription = table.Column<bool>(nullable: false),
                    IsDescriptionMultiline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2Action", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routine2Action_Routine2_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routine2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routine2Autodash",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutineId = table.Column<int>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    ToStep = table.Column<int>(nullable: false),
                    TimeoutDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2Autodash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routine2Autodash_Routine2_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routine2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routine2Notice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutineId = table.Column<int>(nullable: false),
                    FromStep = table.Column<int>(nullable: false),
                    ToStep = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 32, nullable: true),
                    Title = table.Column<string>(maxLength: 512, nullable: true),
                    Body = table.Column<string>(nullable: true),
                    BodySms = table.Column<string>(nullable: true),
                    BodyEmail = table.Column<string>(nullable: true),
                    UserIdsSqlQuery = table.Column<string>(nullable: true),
                    ModelSqlQuery = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2Notice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routine2Notice_Routine2_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routine2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routine2Reminder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutineId = table.Column<int>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    TimeoutDays = table.Column<int>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    BodySms = table.Column<string>(nullable: true),
                    BodyEmail = table.Column<string>(nullable: true),
                    UserIdsSqlQuery = table.Column<string>(nullable: true),
                    ModelSqlQuery = table.Column<string>(nullable: true),
                    Key = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2Reminder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routine2Reminder_Routine2_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routine2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routine2Role",
                columns: table => new
                {
                    RoutineId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    StepsJson = table.Column<string>(maxLength: 2048, nullable: false),
                    DashboardEnum = table.Column<string>(maxLength: 1024, nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2Role", x => x.RoutineId);
                    table.ForeignKey(
                        name: "FK_Routine2Role_Routine2_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routine2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routine2Step",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutineId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 2048, nullable: false),
                    Step = table.Column<int>(nullable: false),
                    F1 = table.Column<int>(nullable: true),
                    F2 = table.Column<int>(nullable: true),
                    F3 = table.Column<int>(nullable: true),
                    F4 = table.Column<int>(nullable: true),
                    F5 = table.Column<int>(nullable: true),
                    F6 = table.Column<int>(nullable: true),
                    F7 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine2Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routine2Step_Routine2_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routine2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notice2_CreatorUserId",
                table: "Notice2",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notice2_RoutineId",
                table: "Notice2",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Notice2_ToUserId",
                table: "Notice2",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Action_RoutineId",
                table: "Routine2Action",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Autodash_RoutineId",
                table: "Routine2Autodash",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Log_CreatorUserId",
                table: "Routine2Log",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Log_UserId",
                table: "Routine2Log",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Notice_RoutineId",
                table: "Routine2Notice",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Reminder_RoutineId",
                table: "Routine2Reminder",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Step_RoutineId",
                table: "Routine2Step",
                column: "RoutineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notice2");

            migrationBuilder.DropTable(
                name: "Routine2Action");

            migrationBuilder.DropTable(
                name: "Routine2Autodash");

            migrationBuilder.DropTable(
                name: "Routine2Log");

            migrationBuilder.DropTable(
                name: "Routine2Notice");

            migrationBuilder.DropTable(
                name: "Routine2Reminder");

            migrationBuilder.DropTable(
                name: "Routine2Role");

            migrationBuilder.DropTable(
                name: "Routine2Step");

            migrationBuilder.DropTable(
                name: "Routine2");
        }
    }
}
