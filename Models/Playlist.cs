using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public int UserId { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
        bool IsPublic { get; set; }
    }
}
