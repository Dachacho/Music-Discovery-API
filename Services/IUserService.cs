using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Services {
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(UserCreateDTO dto);
        Task<string?> LoginUserAsync(UserLoginDTO dto);
    }
}