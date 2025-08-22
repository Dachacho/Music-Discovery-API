using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.DTOs
{
    public class PlaylistDTO
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public int UserId { get; set; }
        public List<int> SongIds { get; set; } = new();
    }
}
