using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieKnight.DataLayer.Migrations
{
    public partial class AddedFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUser1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUser2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_AppUser1Id",
                        column: x => x.AppUser1Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_AppUser2Id",
                        column: x => x.AppUser2Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_AppUser1Id",
                table: "Friends",
                column: "AppUser1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_AppUser2Id",
                table: "Friends",
                column: "AppUser2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
