using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CurrentStreak = table.Column<short>(nullable: false),
                    LongestStreak = table.Column<short>(nullable: false),
                    LogCount = table.Column<short>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BadgeUses",
                columns: table => new
                {
                    HabitID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    badgeID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadgeUses", x => x.HabitID);
                    table.ForeignKey(
                        name: "FK_BadgeUses_Badges_badgeID",
                        column: x => x.badgeID,
                        principalTable: "Badges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "daysOffs",
                columns: table => new
                {
                    HabitId = table.Column<Guid>(nullable: false),
                    daysoff = table.Column<string>(nullable: false),
                    HabitID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_daysOffs", x => x.HabitId);
                    table.ForeignKey(
                        name: "FK_daysOffs_Habits_HabitID",
                        column: x => x.HabitID,
                        principalTable: "Habits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    HabitId = table.Column<Guid>(nullable: false),
                    DateLog = table.Column<DateTime>(nullable: false),
                    HabitID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.HabitId);
                    table.ForeignKey(
                        name: "FK_Logs_Habits_HabitID",
                        column: x => x.HabitID,
                        principalTable: "Habits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BadgeUses_badgeID",
                table: "BadgeUses",
                column: "badgeID");

            migrationBuilder.CreateIndex(
                name: "IX_daysOffs_HabitID",
                table: "daysOffs",
                column: "HabitID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_HabitID",
                table: "Logs",
                column: "HabitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BadgeUses");

            migrationBuilder.DropTable(
                name: "daysOffs");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
