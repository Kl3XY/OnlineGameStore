using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class Communities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_User_UserID",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "funds",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    gameID = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    commentsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Community_Community_commentsID",
                        column: x => x.commentsID,
                        principalTable: "Community",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Community_Game_gameID",
                        column: x => x.gameID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Community_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    gameID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => new { x.gameID, x.userID });
                    table.ForeignKey(
                        name: "FK_Library_Game_gameID",
                        column: x => x.gameID,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Library_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Community_commentsID",
                table: "Community",
                column: "commentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Community_gameID",
                table: "Community",
                column: "gameID");

            migrationBuilder.CreateIndex(
                name: "IX_Community_userID",
                table: "Community",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Library_userID",
                table: "Library",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropColumn(
                name: "funds",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_UserID",
                table: "Game",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_User_UserID",
                table: "Game",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID");
        }
    }
}
