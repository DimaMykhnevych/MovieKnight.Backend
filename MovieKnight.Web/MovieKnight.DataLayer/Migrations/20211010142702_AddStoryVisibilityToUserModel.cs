using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieKnight.DataLayer.Migrations
{
    public partial class AddStoryVisibilityToUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoryVisibility",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryVisibility",
                table: "AspNetUsers");
        }
    }
}
