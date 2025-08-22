using Microsoft.AspNetCore.Mvc;
using MusicDiscoveryAPI.Services;
using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDTO>>> GetAllSongs()
        {
            var songs = await _songService.GetAllSongsAsync();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SongDTO>> GetSongById(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);
            if (song == null) return NotFound();

            return Ok(song);
        }

        [HttpPost]
        public async Task<ActionResult<SongDTO>> CreateSong(SongCreateDTO dto)
        {
            try
            {
                var song = await _songService.CreateSongAsync(dto);
                return CreatedAtAction(nameof(GetSongById), new { id = song.Id }, song);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SongDTO>> UpdateSong(SongCreateDTO dto, int id)
        {
            try
            {
                var updatedSong = await _songService.UpdateSongAsync(dto, id);
                if (updatedSong == null) return NotFound();
                return Ok(updatedSong);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            bool song = await _songService.DeleteSongAsync(id);
            if (song == false) return NotFound();
            return NoContent();
        }
    }
}