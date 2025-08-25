using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicDiscoveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixIsPublicVisibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Playlists",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Playlists");
        }
    }
}
