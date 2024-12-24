using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProject_Joachim_Adomako.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Team 2",
                table: "Matches",
                newName: "Team Id 2");

            migrationBuilder.RenameColumn(
                name: "Team 1",
                table: "Matches",
                newName: "Team Id 1");

            migrationBuilder.CreateIndex(
                name: "IX_players_Team Id",
                table: "players",
                column: "Team Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team Id 1",
                table: "Matches",
                column: "Team Id 1");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team Id 2",
                table: "Matches",
                column: "Team Id 2");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team Id 1",
                table: "Matches",
                column: "Team Id 1",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_Team Id 2",
                table: "Matches",
                column: "Team Id 2",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_players_Teams_Team Id",
                table: "players",
                column: "Team Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team Id 1",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_Team Id 2",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_players_Teams_Team Id",
                table: "players");

            migrationBuilder.DropIndex(
                name: "IX_players_Team Id",
                table: "players");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team Id 1",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team Id 2",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Team Id 2",
                table: "Matches",
                newName: "Team 2");

            migrationBuilder.RenameColumn(
                name: "Team Id 1",
                table: "Matches",
                newName: "Team 1");
        }
    }
}
