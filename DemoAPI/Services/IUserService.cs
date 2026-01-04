using DemoAPI.Dtos;
using DemoAPI.Entities;

namespace DemoAPI.Services
{
    public interface IUserService
    {
        public Task<UserResponse?> GetUserByIdAsync(int id);
        public Task<List<UserResponse>> GetUsersAsync();
        public Task<UserResponse> CreateUserAsync(UserRequest userRequest);
        public Task<UserResponse> UpdateUserAsync(int id, UserRequest userRequest);
        public Task<bool> DeleteUserAsync(int id);
    }
}
