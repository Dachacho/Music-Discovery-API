using AutoMapper;
using MusicDiscoveryAPI.Data;
using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Services
{
    public class SongService : ISongService
    {
        private readonly MusicDiscoveryContext _context;
        private readonly IMapper _mapper;
        public SongService(MusicDiscoveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<SongDTO> CreateSongAsync(SongCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSongAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SongDTO>> GetAllSongsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SongDTO?> GetSongByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SongDTO> UpdateSongAsync(SongCreateDTO dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}