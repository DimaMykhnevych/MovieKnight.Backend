using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieKnight.DataLayer.Migrations
{
    public partial class AddCascadeDeleteForFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_Friend1Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_Friend2Id",
                table: "Friends");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_Friend1Id",
                table: "Friends",
                column: "Friend1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_Friend2Id",
                table: "Friends",
                column: "Friend2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_Friend1Id",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_Friend2Id",
                table: "Friends");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_Friend1Id",
                table: "Friends",
                column: "Friend1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_Friend2Id",
                table: "Friends",
                column: "Friend2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
