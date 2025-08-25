using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Services {
    public interface ISongService
    {
        Task<IEnumerable<SongDTO>> GetAllSongsAsync();
        Task<SongDTO?> GetSongByIdAsync(int id);
        Task<SongDTO> CreateSongAsync(SongCreateDTO dto);
        Task<SongDTO> UpdateSongAsync(SongCreateDTO dto, int id);
        Task<bool> DeleteSongAsync(int id);
        Task<IEnumerable<SongDTO>> SearchSongAsync(string query);
    }
}