using Microsoft.EntityFrameworkCore.Migrations;

namespace EFBlackJacDAL.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardTotal = table.Column<int>(type: "int", nullable: true),
                    HiddenCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiddenCardTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankRoll = table.Column<int>(type: "int", nullable: false),
                    TotalBet = table.Column<int>(type: "int", nullable: false),
                    TotalWinnings = table.Column<int>(type: "int", nullable: false),
                    CardTotal = table.Column<int>(type: "int", nullable: true),
                    BetAmount = table.Column<int>(type: "int", nullable: false),
                    WholeGameBetAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
