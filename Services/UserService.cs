using MusicDiscoveryAPI.Data;
using MusicDiscoveryAPI.Models;
using MusicDiscoveryAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MusicDiscoveryAPI.Services
{
    public class UserService : IUserService
    {
        public readonly MusicDiscoveryContext _context;

        public UserService(MusicDiscoveryContext context)
        {
            _context = context;
        }

        public async Task<string?> LoginUserAsync(UserLoginDTO dto)
        {
            return null;
        }

        public async Task<UserDTO> CreateUserAsync(UserCreateDTO dto)
        {
            bool exists = await _context.Users.AnyAsync(u => u.Email == dto.Email || u.Email == dto.Email);
            if (exists)
            {
                throw new ArgumentException("A user with same Email and or Username Exists");
            }

            var user = new User
            {
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = "" //temporarily
            };

            var hasher = new PasswordHasher<User>();
            var hashedPass = hasher.HashPassword(user, dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            });
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}