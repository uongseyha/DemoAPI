using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class UserService(AppDbContext _context): IUserService
    {
        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            var user = userRequest.Adapt<User>();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Adapt<UserResponse>();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserResponse>> GetUsersAsync()
        {
            return await _context.Users
                .ProjectToType<UserResponse>()
                .ToListAsync();
        }

        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return user.Adapt<UserResponse>();
        }

        public async Task<UserResponse?> UpdateUserAsync(int id, UserRequest userRequest)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.Username = userRequest.Username;
            user.Password = userRequest.Password;
            user.IsAdmin = userRequest.IsAdmin;

            await _context.SaveChangesAsync();

            return user.Adapt<UserResponse>();
        }
    }
}
