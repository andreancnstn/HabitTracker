using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class changesToTableDaysOff2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_daysOffs",
                table: "daysOffs");

            migrationBuilder.AddColumn<Guid>(
                name: "DaysOffID",
                table: "daysOffs",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_daysOffs",
                table: "daysOffs",
                column: "DaysOffID");

            migrationBuilder.CreateIndex(
                name: "IX_daysOffs_HabitID1",
                table: "daysOffs",
                column: "HabitID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_daysOffs",
                table: "daysOffs");

            migrationBuilder.DropIndex(
                name: "IX_daysOffs_HabitID",
                table: "daysOffs");

            migrationBuilder.DropColumn(
                name: "DaysOffID",
                table: "daysOffs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_daysOffs",
                table: "daysOffs",
                column: "HabitID");
        }
    }
}
