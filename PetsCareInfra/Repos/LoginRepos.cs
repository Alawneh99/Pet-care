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
    public class LoginRepos : IloginRepos
    {
        private readonly PetCareDbcontext _context;

        public LoginRepos(PetCareDbcontext context)
        {
            _context = context;
        }
        public async Task<Login> GetLoginByUserId(int userId)
        {

            return await _context.Logins.FirstOrDefaultAsync(l => l.UserId == userId);
        }

        public async Task<Login> GetLoginByUserName(string userName)
        {
            return await _context.Logins.FirstOrDefaultAsync(l => l.UserName == userName);
        }
  
    }
}
