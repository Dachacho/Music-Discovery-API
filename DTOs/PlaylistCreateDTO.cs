using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.DTOs
{
    public class PlaylistCreateDTO
    {
        [Required]
        public required string Name { get; set; }
        public int UserId { get; set; }
        public bool IsPublic { get; set; }
    }
}
