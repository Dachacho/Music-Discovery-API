using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicDiscoveryAPI.Data;
using MusicDiscoveryAPI.DTOs;
using MusicDiscoveryAPI.Models;

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

        public async Task<SongDTO> CreateSongAsync(SongCreateDTO dto)
        {
            var exists = await _context.Songs.AnyAsync(s =>
            s.Title == dto.Title &&
            s.Artist == dto.Artist &&
            s.Album == dto.Album);

             if (exists)
                throw new InvalidOperationException("A song with the same title, artist, and album already exists.");

            var song = _mapper.Map<Song>(dto);

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return _mapper.Map<SongDTO>(song);
        }

        public async Task<bool> DeleteSongAsync(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null) return false;

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SongDTO>> GetAllSongsAsync()
        {
            var songs = await _context.Songs.ToListAsync();
            return songs.Select(_mapper.Map<SongDTO>);
        }

        public async Task<SongDTO?> GetSongByIdAsync(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            return _mapper.Map<SongDTO>(song);
        }

        public async Task<SongDTO> UpdateSongAsync(SongCreateDTO dto, int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null) throw new ArgumentException("Song not found");

            _mapper.Map(dto, song);

            await _context.SaveChangesAsync();
            return _mapper.Map<SongDTO>(song); 
        }

        public async Task<IEnumerable<SongDTO>> SearchSongAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Enumerable.Empty<SongDTO>();
            }

            query = query.ToLower();
        
            var songs = await _context.Songs
            .Where(s =>
                (s.Title != null && s.Title.ToLower().Contains(query)) ||
                (s.Genre != null && s.Genre.ToLower().Contains(query)) ||
               (s.Artist != null && s.Artist.ToLower().Contains(query)))
            .ToListAsync();
        
            return songs.Select(_mapper.Map<SongDTO>);
        }
    }
}