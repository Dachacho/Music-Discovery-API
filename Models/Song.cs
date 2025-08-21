using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Artist { get; set; }
        public string? Album { get; set; }
        public string? Duration { get; set; }
        public required string? Genre { get; set; }
        public required string? ReleaseYear { get; set; }
    }
}
