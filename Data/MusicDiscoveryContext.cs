using Microsoft.EntityFrameworkCore;
using MusicDiscoveryAPI.Models;

namespace MusicDiscoveryAPI.Data
{
    public class MusicDiscoveryContext : DbContext
    {
        public MusicDiscoveryContext(DbContextOptions<MusicDiscoveryContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Imagine", Artist = "John Lennon", Album = "Imagine", Duration = "3:04", Genre = "Rock", ReleaseYear = "1971" },
                new Song { Id = 2, Title = "Billie Jean", Artist = "Michael Jackson", Album = "Thriller", Duration = "4:54", Genre = "Pop", ReleaseYear = "1982" },
                new Song { Id = 3, Title = "Bohemian Rhapsody", Artist = "Queen", Album = "A Night at the Opera", Duration = "5:55", Genre = "Rock", ReleaseYear = "1975" },
                new Song { Id = 4, Title = "Shape of You", Artist = "Ed Sheeran", Album = "Divide", Duration = "3:53", Genre = "Pop", ReleaseYear = "2017" },
                new Song { Id = 5, Title = "Lose Yourself", Artist = "Eminem", Album = "8 Mile", Duration = "5:26", Genre = "Hip-Hop", ReleaseYear = "2002" },
                new Song { Id = 6, Title = "Rolling in the Deep", Artist = "Adele", Album = "21", Duration = "3:48", Genre = "Soul", ReleaseYear = "2010" },
                new Song { Id = 7, Title = "Smells Like Teen Spirit", Artist = "Nirvana", Album = "Nevermind", Duration = "5:01", Genre = "Grunge", ReleaseYear = "1991" },
                new Song { Id = 8, Title = "Blinding Lights", Artist = "The Weeknd", Album = "After Hours", Duration = "3:20", Genre = "Synthpop", ReleaseYear = "2019" },
                new Song { Id = 9, Title = "Uptown Funk", Artist = "Mark Ronson ft. Bruno Mars", Album = "Uptown Special", Duration = "4:30", Genre = "Funk", ReleaseYear = "2014" },
                new Song { Id = 10, Title = "Viva La Vida", Artist = "Coldplay", Album = "Viva la Vida or Death and All His Friends", Duration = "4:02", Genre = "Alternative", ReleaseYear = "2008" }
            ); 
        }
    }
}