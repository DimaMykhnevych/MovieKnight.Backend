using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieKnight.DataLayer.Migrations
{
    public partial class AddedWatchAndCommentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WatchHistory_watchHistoryId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "watchHistoryId",
                table: "Comments",
                newName: "WatchHistoryId");

            migrationBuilder.RenameColumn(
                name: "commentText",
                table: "Comments",
                newName: "CommentText");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_watchHistoryId",
                table: "Comments",
                newName: "IX_Comments_WatchHistoryId");

            migrationBuilder.AddColumn<DateTime>(
                name: "WatchDate",
                table: "WatchHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WatchHistory_WatchHistoryId",
                table: "Comments",
                column: "WatchHistoryId",
                principalTable: "WatchHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_WatchHistory_WatchHistoryId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "WatchDate",
                table: "WatchHistory");

            migrationBuilder.DropColumn(
                name: "CommentDate",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "WatchHistoryId",
                table: "Comments",
                newName: "watchHistoryId");

            migrationBuilder.RenameColumn(
                name: "CommentText",
                table: "Comments",
                newName: "commentText");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_WatchHistoryId",
                table: "Comments",
                newName: "IX_Comments_watchHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_WatchHistory_watchHistoryId",
                table: "Comments",
                column: "watchHistoryId",
                principalTable: "WatchHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
