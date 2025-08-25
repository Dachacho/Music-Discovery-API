using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.DTOs
{
    public class SongCreateDTO
    {
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Artist { get; set; }
        public string? Album { get; set; }
        public string? Duration { get; set; }
        public string? Genre { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
