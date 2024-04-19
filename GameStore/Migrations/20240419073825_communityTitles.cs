using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class communityTitles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_Reply_commentsID",
                table: "Community");

            migrationBuilder.DropIndex(
                name: "IX_Community_commentsID",
                table: "Community");

            migrationBuilder.DropColumn(
                name: "commentsID",
                table: "Community");

            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "Reply",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "commentID",
                table: "Reply",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Community",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reply_commentID",
                table: "Reply",
                column: "commentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Community_commentID",
                table: "Reply",
                column: "commentID",
                principalTable: "Community",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Community_commentID",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Reply_commentID",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "commentID",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Community");

            migrationBuilder.AlterColumn<int>(
                name: "message",
                table: "Reply",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "commentsID",
                table: "Community",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Community_commentsID",
                table: "Community",
                column: "commentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Reply_commentsID",
                table: "Community",
                column: "commentsID",
                principalTable: "Reply",
                principalColumn: "ID");
        }
    }
}
