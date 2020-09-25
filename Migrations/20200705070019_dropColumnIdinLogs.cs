using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class dropColumnIdinLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
