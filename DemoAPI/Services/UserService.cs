using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class UserService(AppDbContext _context): IUserService
    {
        public async Task<UserDto> CreateUserAsync(UserCreateDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                IsAdmin = userDto.IsAdmin
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            return await _context.Users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Password = u.Password,
                IsAdmin = u.IsAdmin
            })
            .ToListAsync();
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }

        public async Task<UserDto?> UpdateUserAsync(int id, UserCreateDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.Username = userDto.Username;
            user.Password = userDto.Password;
            user.IsAdmin = userDto.IsAdmin;

            await _context.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
