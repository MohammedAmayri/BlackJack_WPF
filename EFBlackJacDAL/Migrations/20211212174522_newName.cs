using Microsoft.EntityFrameworkCore.Migrations;

namespace EFBlackJacDAL.Migrations
{
    public partial class newName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_playingHabits_PlayerPlayingHabbitsHabitId",
                table: "Players");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_playingHabits_PlayerPlayingHabbitsHabitId",
                table: "Players",
                column: "PlayerPlayingHabbitsHabitId",
                principalTable: "playingHabits",
                principalColumn: "HabitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_playingHabits_PlayerPlayingHabbitsHabitId",
                table: "Players");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_playingHabits_PlayerPlayingHabbitsHabitId",
                table: "Players",
                column: "PlayerPlayingHabbitsHabitId",
                principalTable: "playingHabits",
                principalColumn: "HabitId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
