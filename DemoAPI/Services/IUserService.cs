using DemoAPI.Dtos;
using DemoAPI.Models;

namespace DemoAPI.Services
{
    public interface IUserService
    {
        public Task<UserDto?> GetUserByIdAsync(int id);
        public Task<List<UserDto>> GetUsersAsync();
        public Task<UserDto> CreateUserAsync(UserCreateDto userDto);
        public Task<UserDto> UpdateUserAsync(int id, UserCreateDto userDto);
        public Task<bool> DeleteUserAsync(int id);
    }
}
