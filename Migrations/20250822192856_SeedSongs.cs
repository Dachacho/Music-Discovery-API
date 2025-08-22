using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicDiscoveryAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "Duration", "Genre", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Imagine", "John Lennon", "3:04", "Rock", "1971", "Imagine" },
                    { 2, "Thriller", "Michael Jackson", "4:54", "Pop", "1982", "Billie Jean" },
                    { 3, "A Night at the Opera", "Queen", "5:55", "Rock", "1975", "Bohemian Rhapsody" },
                    { 4, "Divide", "Ed Sheeran", "3:53", "Pop", "2017", "Shape of You" },
                    { 5, "8 Mile", "Eminem", "5:26", "Hip-Hop", "2002", "Lose Yourself" },
                    { 6, "21", "Adele", "3:48", "Soul", "2010", "Rolling in the Deep" },
                    { 7, "Nevermind", "Nirvana", "5:01", "Grunge", "1991", "Smells Like Teen Spirit" },
                    { 8, "After Hours", "The Weeknd", "3:20", "Synthpop", "2019", "Blinding Lights" },
                    { 9, "Uptown Special", "Mark Ronson ft. Bruno Mars", "4:30", "Funk", "2014", "Uptown Funk" },
                    { 10, "Viva la Vida or Death and All His Friends", "Coldplay", "4:02", "Alternative", "2008", "Viva La Vida" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
