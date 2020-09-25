using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class changeLogDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.AddColumn<Guid>(
                name: "LogId",
                table: "Logs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_HabitId1",
                table: "Logs",
                column: "HabitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_HabitId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "LogId",
                table: "Logs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "HabitId");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Logs");
        }
    }
}
