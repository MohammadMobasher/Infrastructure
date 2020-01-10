using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class ssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Step",
                table: "Routine2Step");

            migrationBuilder.DropIndex(
                name: "IX_Routine2Step_RoutineId",
                table: "Routine2Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Role",
                table: "Routine2Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Reminder",
                table: "Routine2Reminder");

            migrationBuilder.DropIndex(
                name: "IX_Routine2Reminder_RoutineId",
                table: "Routine2Reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Notice",
                table: "Routine2Notice");

            migrationBuilder.DropIndex(
                name: "IX_Routine2Notice_RoutineId",
                table: "Routine2Notice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Autodash",
                table: "Routine2Autodash");

            migrationBuilder.DropIndex(
                name: "IX_Routine2Autodash_RoutineId",
                table: "Routine2Autodash");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Action",
                table: "Routine2Action");

            migrationBuilder.DropIndex(
                name: "IX_Routine2Action_RoutineId",
                table: "Routine2Action");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Routine2Step");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Routine2Role");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Routine2Reminder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Routine2Notice");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Routine2Autodash");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Routine2Action");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Routine2Reminder",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Routine2Notice",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Routine2Action",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Step",
                table: "Routine2Step",
                columns: new[] { "RoutineId", "Step" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Role",
                table: "Routine2Role",
                columns: new[] { "RoutineId", "DashboardEnum" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Reminder",
                table: "Routine2Reminder",
                columns: new[] { "RoutineId", "Step", "Key", "TimeoutDays" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Notice",
                table: "Routine2Notice",
                columns: new[] { "RoutineId", "FromStep", "ToStep", "Key" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Autodash",
                table: "Routine2Autodash",
                columns: new[] { "RoutineId", "Step", "ToStep" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Action",
                table: "Routine2Action",
                columns: new[] { "RoutineId", "Step", "Action" });

            migrationBuilder.CreateTable(
                name: "TestRoutin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    RoutineStep = table.Column<int>(nullable: false),
                    RoutineIsFlown = table.Column<bool>(nullable: false),
                    RoutineIsDone = table.Column<bool>(nullable: false),
                    RoutineFlownDate = table.Column<DateTime>(nullable: true),
                    RoutineStepChangeDate = table.Column<DateTime>(nullable: true),
                    RoutineIsSucceeded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRoutin", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestRoutin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Step",
                table: "Routine2Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Role",
                table: "Routine2Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Reminder",
                table: "Routine2Reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Notice",
                table: "Routine2Notice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Autodash",
                table: "Routine2Autodash");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine2Action",
                table: "Routine2Action");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Routine2Step",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Routine2Role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Routine2Reminder",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Routine2Reminder",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "Routine2Notice",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Routine2Notice",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Routine2Autodash",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Routine2Action",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Routine2Action",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Step",
                table: "Routine2Step",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Role",
                table: "Routine2Role",
                column: "RoutineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Reminder",
                table: "Routine2Reminder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Notice",
                table: "Routine2Notice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Autodash",
                table: "Routine2Autodash",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine2Action",
                table: "Routine2Action",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Step_RoutineId",
                table: "Routine2Step",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Reminder_RoutineId",
                table: "Routine2Reminder",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Notice_RoutineId",
                table: "Routine2Notice",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Autodash_RoutineId",
                table: "Routine2Autodash",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routine2Action_RoutineId",
                table: "Routine2Action",
                column: "RoutineId");
        }
    }
}
