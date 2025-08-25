using Microsoft.AspNetCore.Mvc;
using MusicDiscoveryAPI.Services;
using MusicDiscoveryAPI.DTOs;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("public")]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> GetAllPublicPlaylists()
        {
            var playlists = await _playlistService.GetAllPublicPlaylistsAsync();
            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistDTO>> GetPlaylistById(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist == null) return NotFound();

            return Ok(playlist);
        }

        [HttpGet("my")]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> GetPlaylistByUserId()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);
            var playlists = await _playlistService.GetPlaylistByUserAsync(userId);
            if (playlists == null || !playlists.Any()) return NotFound();

            return Ok(playlists);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost("{playlistId}/songs")]
        public async Task<ActionResult<PlaylistDTO>> AddSongToPlaylist(int playlistId, PlaylistAddDTO dto)
        {
            try
            {
                var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                if (userIdClaim == null) return Unauthorized();

                var playlist = await _playlistService.GetPlaylistByIdAsync(playlistId);
                if (playlist == null || playlist.UserId != int.Parse(userIdClaim.Value))
                {
                    return NotFound();
                }

                dto.PlaylistId = playlistId;
                var updatedPlaylist = await _playlistService.PlaylistAddSongAsync(dto);
                return Ok(updatedPlaylist);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{playlistId}/songs")]
        public async Task<IActionResult> RemoveSongToPlaylist(int playlistId, PlaylistAddDTO dto)
        {
            try
            {
                var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                if (userIdClaim == null) return Unauthorized();

                var playlist = await _playlistService.GetPlaylistByIdAsync(playlistId);
                if (playlist == null || playlist.UserId != int.Parse(userIdClaim.Value))
                {
                    return NotFound();
                }

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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);

            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            if (playlist == null || playlist.UserId != int.Parse(userIdClaim.Value))
            {
                return NotFound();
            }

            var deleted = await _playlistService.DeletePlaylistAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{playlistId}/public")]
        public async Task<IActionResult> SetPlaylistPublicStatus(int playlistId, bool isPublic)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);

            try
            {
                var result = await _playlistService.SetPlaylistPublicStatusAsync(playlistId, userId, isPublic);
                if (!result) return NotFound();
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}