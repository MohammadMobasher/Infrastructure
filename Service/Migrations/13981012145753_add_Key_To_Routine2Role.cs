using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.Migrations
{
    public partial class add_Key_To_Routine2Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Routine2Role",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Routine2Role");
        }
    }
}
