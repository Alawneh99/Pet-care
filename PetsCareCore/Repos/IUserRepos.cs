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
        public interface IUserRepository
        {
            Task<User> CreateUser(User user);
            Task<User> GetUserById(int userId);
            Task UpdateUser(User user);
            Task DeleteUser(int userId);
        }

    }
}
