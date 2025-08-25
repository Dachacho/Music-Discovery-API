using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicDiscoveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndPlaylists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "hash1", "alice" },
                    { 2, "bob@example.com", "hash2", "bob" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "Id", "IsPublic", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Alice's Public", 1 },
                    { 2, false, "Alice's Private", 1 },
                    { 3, true, "Bob's Public", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
