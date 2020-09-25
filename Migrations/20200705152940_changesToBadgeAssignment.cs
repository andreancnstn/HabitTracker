using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class changesToBadgeAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BadgeUses",
                table: "BadgeUses");

            migrationBuilder.AddColumn<int>(
                name: "BadgeUsesID",
                table: "BadgeUses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BadgeUses",
                table: "BadgeUses",
                column: "BadgeUsesID");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeUses_BadgeID",
                table: "BadgeUses",
                column: "BadgeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BadgeUses",
                table: "BadgeUses");

            migrationBuilder.DropIndex(
                name: "IX_BadgeUses_BadgeID",
                table: "BadgeUses");

            migrationBuilder.DropColumn(
                name: "BadgeUsesID",
                table: "BadgeUses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BadgeUses",
                table: "BadgeUses",
                column: "BadgeID");
        }
    }
}
