using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class changestoHabits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_daysOffs_HabitID",
                table: "daysOffs");

            migrationBuilder.CreateIndex(
                name: "IX_daysOffs_HabitID",
                table: "daysOffs",
                column: "HabitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_daysOffs_HabitID",
                table: "daysOffs");

            migrationBuilder.CreateIndex(
                name: "IX_daysOffs_HabitID",
                table: "daysOffs",
                column: "HabitID",
                unique: true);
        }
    }
}
