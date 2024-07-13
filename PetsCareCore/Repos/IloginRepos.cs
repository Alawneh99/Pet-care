using PetsCareCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareCore.Repos
{
    public interface IloginRepos
    {
        Task<Login> GetLoginByEmail(string email);
        Task<Login> GetLoginByUserId(int userId);
        Task UpdateLogin(Login login);
        Task CreateLogin(Login login);
    }
}
