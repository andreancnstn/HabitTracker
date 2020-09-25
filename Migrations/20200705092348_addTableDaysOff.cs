using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class addTableDaysOff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DaysOff_Habits_HabitID",
                table: "DaysOff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DaysOff",
                table: "DaysOff");

            migrationBuilder.RenameTable(
                name: "DaysOff",
                newName: "daysOffs");

            migrationBuilder.RenameIndex(
                name: "IX_DaysOff_HabitID",
                table: "daysOffs",
                newName: "IX_daysOffs_HabitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_daysOffs",
                table: "daysOffs",
                column: "DaysOffID");

            migrationBuilder.AddForeignKey(
                name: "FK_daysOffs_Habits_HabitID",
                table: "daysOffs",
                column: "HabitID",
                principalTable: "Habits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_daysOffs_Habits_HabitID",
                table: "daysOffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_daysOffs",
                table: "daysOffs");

            migrationBuilder.RenameTable(
                name: "daysOffs",
                newName: "DaysOff");

            migrationBuilder.RenameIndex(
                name: "IX_daysOffs_HabitID",
                table: "DaysOff",
                newName: "IX_DaysOff_HabitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DaysOff",
                table: "DaysOff",
                column: "DaysOffID");

            migrationBuilder.AddForeignKey(
                name: "FK_DaysOff_Habits_HabitID",
                table: "DaysOff",
                column: "HabitID",
                principalTable: "Habits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
