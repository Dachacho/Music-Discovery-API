using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicDiscoveryAPI.Data;
using MusicDiscoveryAPI.DTOs;
using MusicDiscoveryAPI.Models;

namespace MusicDiscoveryAPI.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly MusicDiscoveryContext _context;
        private readonly IMapper _mapper;
        public PlaylistService(MusicDiscoveryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<PlaylistDTO> CreatePlaylistAsync(PlaylistCreateDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlaylistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaylistDTO>> GetAllPlaylistsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaylistDTO>> GetPlaylistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistDTO?> GetPlaylistByUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<PlaylistDTO> PlaylistAddSongAsync(PlaylistAddDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveSongFromPlaylistAsync(PlaylistAddDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}