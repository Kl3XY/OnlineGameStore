using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class commentsRelationSettingsFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserID2",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID2",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserID2",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID2",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID2",
                table: "Comments",
                column: "UserID2");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserID2",
                table: "Comments",
                column: "UserID2",
                principalTable: "User",
                principalColumn: "ID");
        }
    }
}
