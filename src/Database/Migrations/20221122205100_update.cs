using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CallId",
                table: "Log",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "Log",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallId",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Log");
        }
    }
}
