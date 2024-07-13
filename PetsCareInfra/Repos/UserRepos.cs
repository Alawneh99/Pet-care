using Microsoft.EntityFrameworkCore;
using PetsCareCore.Context;
using PetsCareCore.Models.Entities;
using PetsCareCore.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareInfra.Repos
{
    public class UserRepos: IUserRepos
    {
        private readonly PetCareDbcontext _context;

        public UserRepos(PetCareDbcontext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int userId)
        {
            var user = await GetUserById(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<UserRole> GetUserRole(int? roleID)
        {
            if (!roleID.HasValue)
                throw new ArgumentException("Role ID is null", nameof(roleID));

            return await _context.Roles.FindAsync(roleID.Value);
        }

        public async Task SetPasswordResetToken(User user, string token, DateTime expiry)
        {
            user.ResetPasswordToken = token;
            user.ResetPasswordExpiry = expiry;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
