using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Database_SQL;
using server.DTO;
using server.Models;

namespace server.Services.UserSV
{
    public class UserRepo : IUserRepo
    {
        public readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(_context));
        }
        public async Task<User?> AddNewUser(UserDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "UserDTO cannot be null");
            }

            if (await IsUser(model.Username, model.PhoneNumber, model.Email))
            {
                return null; // User đã tồn tại
            }

            var passwordKey = GeneretePasswordKey(); 
            var passwordHash = HashPassword(model.Password, passwordKey); 

            var user = new User
            {
                Username = model.Username,
                PasswordKey = passwordKey,
                PasswordHash = passwordHash, 
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Gender = model.Gender ?? false,
                DateOfBirth = model.DateOfBirth,
                isLocked = false,
                CreatedAt = DateTime.Now
            };
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khi thêm user: {ex.Message}");
                return null;
            }
        }
        public string GeneretePasswordKey()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 5);
        }

        public string HashPassword(string password, string passwordKey)
        {
            return BCrypt.Net.BCrypt.HashPassword(password + passwordKey);
        }


        public async Task<bool> IsUser(string username, string phoneNumber, string email)
        {
            return await _context.Users.AnyAsync(u => u.Username == username || u.PhoneNumber == phoneNumber || u.Email == email);
        }
    }
}