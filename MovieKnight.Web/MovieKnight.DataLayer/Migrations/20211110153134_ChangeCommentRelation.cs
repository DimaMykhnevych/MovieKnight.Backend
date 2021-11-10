using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieKnight.DataLayer.Migrations
{
    public partial class ChangeCommentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WatchHistory_WatchHistoryId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "WatchHistoryId",
                table: "Comments",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_WatchHistoryId",
                table: "Comments",
                newName: "IX_Comments_MovieId");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Comments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Movies_MovieId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Comments",
                newName: "WatchHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MovieId",
                table: "Comments",
                newName: "IX_Comments_WatchHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WatchHistory_WatchHistoryId",
                table: "Comments",
                column: "WatchHistoryId",
                principalTable: "WatchHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
