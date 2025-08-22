using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Email { get; set; }
        public List<int> PlaylistIds { get; set; } = new();
    }
}