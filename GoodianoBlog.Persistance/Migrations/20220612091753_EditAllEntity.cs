using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoodianoBlog.Persistance.Migrations
{
    public partial class EditAllEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstSlideSrc",
                table: "PostCategories");

            migrationBuilder.AddColumn<string>(
                name: "FirstSlideSrc",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PostCategoriesId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "PostCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoriesId",
                table: "Posts",
                column: "PostCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_ParentCategoryId",
                table: "PostCategories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategories_PostCategories_ParentCategoryId",
                table: "PostCategories",
                column: "ParentCategoryId",
                principalTable: "PostCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostCategories_PostCategoriesId",
                table: "Posts",
                column: "PostCategoriesId",
                principalTable: "PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategories_PostCategories_ParentCategoryId",
                table: "PostCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCategories_PostCategoriesId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostCategoriesId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_PostCategories_ParentCategoryId",
                table: "PostCategories");

            migrationBuilder.DropColumn(
                name: "FirstSlideSrc",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostCategoriesId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "PostCategories");

            migrationBuilder.AddColumn<string>(
                name: "FirstSlideSrc",
                table: "PostCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
