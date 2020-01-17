using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_field_to_PromotionBasicInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRequest",
                table: "PromotionBasicInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRequest",
                table: "PromotionBasicInfo");
        }
    }
}
