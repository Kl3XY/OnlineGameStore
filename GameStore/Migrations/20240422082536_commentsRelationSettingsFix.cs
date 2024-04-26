using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class commentsRelationSettingsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID2",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID1",
                table: "Comments",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID2",
                table: "Comments",
                column: "UserID2");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserID1",
                table: "Comments",
                column: "UserID1",
                principalTable: "User",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserID2",
                table: "Comments",
                column: "UserID2",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserID1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserID2",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID2",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserID2",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
