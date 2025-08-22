using Microsoft.AspNetCore.Mvc;
using MusicDiscoveryAPI.Services;
using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> GetAllPlaylists()
        {
            var playlists = await _playlistService.GetAllPlaylistsAsync();
            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistDTO>> GetPlaylistById(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null) return NotFound();

            return Ok(playlist);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> GetPlaylistByUserId(int userId)
        {
            var playlists = await _playlistService.GetPlaylistByUserAsync(userId);
            if (playlists == null || !playlists.Any()) return NotFound();

            return Ok(playlists);
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistDTO>> CreatePlaylist(PlaylistCreateDTO dto)
        {
            try
            {
                var playlist = await _playlistService.CreatePlaylistAsync(dto);
                return CreatedAtAction(nameof(GetPlaylistById), new { id = playlist.Id }, playlist);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{playlistId}/songs")]
        public async Task<ActionResult<PlaylistDTO>> AddSongToPlaylist(int playlistId, PlaylistAddDTO dto)
        {
            try
            {
                dto.PlaylistId = playlistId;
                var playlist = await _playlistService.PlaylistAddSongAsync(dto);
                return Ok(playlist);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{playlistId}/songs")]
        public async Task<IActionResult> RemoveSongToPlaylist(int playlistId, PlaylistAddDTO dto)
        {
            try
            {
                dto.PlaylistId = playlistId;
                var removed = await _playlistService.RemoveSongFromPlaylistAsync(dto);
                if (!removed)
                {
                    return NotFound("playlist not found");
                }

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var deleted = await _playlistService.DeletePlaylistAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}