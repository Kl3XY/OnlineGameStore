using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class addedComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_Community_commentsID",
                table: "Community");

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    communityPostID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Reply_commentsID",
                table: "Community",
                column: "commentsID",
                principalTable: "Reply",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_Reply_commentsID",
                table: "Community");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Community_commentsID",
                table: "Community",
                column: "commentsID",
                principalTable: "Community",
                principalColumn: "ID");
        }
    }
}
