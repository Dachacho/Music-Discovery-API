using System.ComponentModel.DataAnnotations;

namespace MusicDiscoveryAPI.DTOs
{
    public class PlaylistAddDTO
    {

        public int PlaylistId { get; set; }
        public int Songid { get; set; }
    }
}
