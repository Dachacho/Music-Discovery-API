using MusicDiscoveryAPI.Data;
using MusicDiscoveryAPI.Models;
using MusicDiscoveryAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MusicDiscoveryAPI.Services
{
    public class UserService : IUserService
    {
        private readonly MusicDiscoveryContext _context;
        private readonly IConfiguration _configuration;

        public UserService(MusicDiscoveryContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT Key not present in config");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string?> LoginUserAsync(UserLoginDTO dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null) return null;
            var hasher = new PasswordHasher<User>();

            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Success)
            {
                return GenerateJwtToken(user);
            }
            else
            {
                throw new ArgumentException("Non Valid Credentials");
            };
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