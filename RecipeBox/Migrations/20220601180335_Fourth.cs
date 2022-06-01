using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBox.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_AspNetUsers_ApplicationUserId",
                table: "UserRecipes");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UserRecipes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipes_ApplicationUserId",
                table: "UserRecipes",
                newName: "IX_UserRecipes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_AspNetUsers_UserId",
                table: "UserRecipes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_AspNetUsers_UserId",
                table: "UserRecipes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserRecipes",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipes_UserId",
                table: "UserRecipes",
                newName: "IX_UserRecipes_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_AspNetUsers_ApplicationUserId",
                table: "UserRecipes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
