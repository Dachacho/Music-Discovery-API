using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Artist { get; set; }
        public string? Album { get; set; }
        public int? Duration { get; set; }
        public string? Genre { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
