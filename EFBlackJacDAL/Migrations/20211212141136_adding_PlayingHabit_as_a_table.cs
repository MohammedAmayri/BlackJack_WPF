using Microsoft.EntityFrameworkCore.Migrations;

namespace EFBlackJacDAL.Migrations
{
    public partial class adding_PlayingHabit_as_a_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayingHabit_PlayerPlayingHabbitsHabitId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayingHabit",
                table: "PlayingHabit");

            migrationBuilder.RenameTable(
                name: "PlayingHabit",
                newName: "playingHabits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playingHabits",
                table: "playingHabits",
                column: "HabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_playingHabits_PlayerPlayingHabbitsHabitId",
                table: "Players",
                column: "PlayerPlayingHabbitsHabitId",
                principalTable: "playingHabits",
                principalColumn: "HabitId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_playingHabits_PlayerPlayingHabbitsHabitId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playingHabits",
                table: "playingHabits");

            migrationBuilder.RenameTable(
                name: "playingHabits",
                newName: "PlayingHabit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayingHabit",
                table: "PlayingHabit",
                column: "HabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayingHabit_PlayerPlayingHabbitsHabitId",
                table: "Players",
                column: "PlayerPlayingHabbitsHabitId",
                principalTable: "PlayingHabit",
                principalColumn: "HabitId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
