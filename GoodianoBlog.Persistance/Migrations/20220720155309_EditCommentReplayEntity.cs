using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodianoBlog.Persistance.Migrations
{
    public partial class EditCommentReplayEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReplay_Comments_CommentId",
                table: "CommentReplay");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentReplay_Posts_PostId",
                table: "CommentReplay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentReplay",
                table: "CommentReplay");

            migrationBuilder.DropIndex(
                name: "IX_CommentReplay_PostId",
                table: "CommentReplay");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "CommentReplay");

            migrationBuilder.RenameTable(
                name: "CommentReplay",
                newName: "CommentReplays");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "CommentReplays",
                newName: "CommentsId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentReplay_CommentId",
                table: "CommentReplays",
                newName: "IX_CommentReplays_CommentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentReplays",
                table: "CommentReplays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReplays_Comments_CommentsId",
                table: "CommentReplays",
                column: "CommentsId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReplays_Comments_CommentsId",
                table: "CommentReplays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentReplays",
                table: "CommentReplays");

            migrationBuilder.RenameTable(
                name: "CommentReplays",
                newName: "CommentReplay");

            migrationBuilder.RenameColumn(
                name: "CommentsId",
                table: "CommentReplay",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentReplays_CommentsId",
                table: "CommentReplay",
                newName: "IX_CommentReplay_CommentId");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "CommentReplay",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentReplay",
                table: "CommentReplay",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReplay_PostId",
                table: "CommentReplay",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReplay_Comments_CommentId",
                table: "CommentReplay",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReplay_Posts_PostId",
                table: "CommentReplay",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
