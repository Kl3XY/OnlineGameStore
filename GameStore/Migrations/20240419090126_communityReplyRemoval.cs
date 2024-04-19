using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.Migrations
{
    /// <inheritdoc />
    public partial class communityReplyRemoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reply");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentID = table.Column<int>(type: "int", nullable: true),
                    communityPostID = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reply_Community_commentID",
                        column: x => x.commentID,
                        principalTable: "Community",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reply_commentID",
                table: "Reply",
                column: "commentID");
        }
    }
}
