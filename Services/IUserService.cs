using MusicDiscoveryAPI.DTOs;

namespace MusicDiscoveryAPI.Services {
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO?> GetUserById(int id);
        Task<UserDTO> CreateUser(UserCreateDTO dto);
    }
}