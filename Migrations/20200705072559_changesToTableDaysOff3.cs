using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class changesToTableDaysOff3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "daysOffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
