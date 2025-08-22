using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Services {
    public interface IPlaylistService
    {
        Task<IEnumerable<PlaylistDTO>> GetAllPlaylistsAsync();
        Task<PlaylistDTO?> GetPlaylistByIdAsync(int id);
        Task<IEnumerable<PlaylistDTO>> GetPlaylistByUserAsync(int userId);
        Task<PlaylistDTO> CreatePlaylistAsync(PlaylistCreateDTO dto);
        Task<PlaylistDTO> PlaylistAddSongAsync(PlaylistAddDTO dto);
        Task<bool> RemoveSongFromPlaylistAsync(PlaylistAddDTO dto);
        Task<bool> DeletePlaylistAsync(int id);
    }
}