using Microsoft.EntityFrameworkCore.Migrations;

namespace EFBlackJacDAL.Migrations
{
    public partial class updateRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerPlayingHabbitsHabitId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayingHabit",
                columns: table => new
                {
                    HabitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoGameDays = table.Column<int>(type: "int", nullable: false),
                    MoneySpent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayingHabit", x => x.HabitId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerPlayingHabbitsHabitId",
                table: "Players",
                column: "PlayerPlayingHabbitsHabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayingHabit_PlayerPlayingHabbitsHabitId",
                table: "Players",
                column: "PlayerPlayingHabbitsHabitId",
                principalTable: "PlayingHabit",
                principalColumn: "HabitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayingHabit_PlayerPlayingHabbitsHabitId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayingHabit");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerPlayingHabbitsHabitId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerPlayingHabbitsHabitId",
                table: "Players");
        }
    }
}
