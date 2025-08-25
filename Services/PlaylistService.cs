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

        public async Task<PlaylistDTO> CreatePlaylistAsync(PlaylistCreateDTO dto)
        {
            bool exists = await _context.Playlists.AnyAsync(p =>
                p.Name == dto.Name && p.UserId == dto.UserId);

            if (exists)
                throw new InvalidOperationException("A playlist with this name already exists for this user.");

            var playlist = _mapper.Map<Playlist>(dto);

            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return _mapper.Map<PlaylistDTO>(playlist);
        }

        public async Task<bool> DeletePlaylistAsync(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null) return false;

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PlaylistDTO>> GetAllPlaylistsAsync()
        {
            var playlists = await _context.Playlists.ToListAsync();
            return playlists.Select(_mapper.Map<PlaylistDTO>);
        }

        public async Task<IEnumerable<PlaylistDTO>> GetAllPublicPlaylistsAsync()
        {
            var playlists = await _context.Playlists.Where(p => p.IsPublic == true).ToListAsync();
            return playlists.Select(_mapper.Map<PlaylistDTO>);
        }

        public async Task<PlaylistDTO?> GetPlaylistByIdAsync(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            return _mapper.Map<PlaylistDTO>(playlist);
        }

        public async Task<IEnumerable<PlaylistDTO>> GetPlaylistByUserAsync(int userId)
        {
            var playlists = await _context.Playlists
            .Where(p => p.UserId == userId).ToListAsync();
            return playlists.Select(_mapper.Map<PlaylistDTO>);
        }

        public async Task<PlaylistDTO> PlaylistAddSongAsync(PlaylistAddDTO dto)
        {
            var playlist = await _context.Playlists.Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.Id == dto.PlaylistId);
            var song = await _context.Songs.FindAsync(dto.SongId);

            if (playlist == null || song == null)
            {
                throw new InvalidOperationException("Playlist or song not found");
            }

            if (!playlist.Songs.Contains(song))
            {
                playlist.Songs.Add(song);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<PlaylistDTO>(playlist);
        }

        public async Task<bool> RemoveSongFromPlaylistAsync(PlaylistAddDTO dto)
        {
            var playlist = await _context.Playlists.Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.Id == dto.PlaylistId);
            var song = await _context.Songs.FindAsync(dto.SongId);

            if (playlist == null || song == null)
            {
                throw new InvalidOperationException("Playlist or song not found");
            }

            if (!playlist.Songs.Contains(song))
            {
                return false;
            }
            else
            {
                playlist.Songs.Remove(song);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SetPlaylistPublicStatusAsync(int playlistId, int userId, bool isPublic)
        {
            var playlist = await _context.Playlists.FindAsync(playlistId);

            if (playlist == null)
            {
                throw new ArgumentException("Plese provide correct PlaylistId");
            }

            if (playlist.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not the owner of the playlist");
            }

            playlist.IsPublic = isPublic;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}