using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapCloud.Games.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "varchar(150)", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGameLibraries",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameLibraries", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserOwnedGames",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    GameId = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserGameLibraryUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOwnedGames", x => new { x.UserId, x.GameId });
                    table.ForeignKey(
                        name: "FK_UserOwnedGames_UserGameLibraries_UserGameLibraryUserId",
                        column: x => x.UserGameLibraryUserId,
                        principalTable: "UserGameLibraries",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserOwnedGames_UserGameLibraries_UserId",
                        column: x => x.UserId,
                        principalTable: "UserGameLibraries",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserOwnedGames_UserGameLibraryUserId",
                table: "UserOwnedGames",
                column: "UserGameLibraryUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "UserOwnedGames");

            migrationBuilder.DropTable(
                name: "UserGameLibraries");
        }
    }
}
