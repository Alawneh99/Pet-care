using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IUserRepos
    {
        
            Task<User> CreateUser(User user);
            Task<User> GetUserById(int userId);
            Task<User> GetUserByEmail(string email);
            Task<UserRole> GetUserRole(int? roleID);
            Task UpdateUser(User user);
            Task DeleteUser(int userId);
            Task SetPasswordResetToken(User user, string token, DateTime expiry);
            Task<IEnumerable<User>> GetAllUsers();
    }
}
