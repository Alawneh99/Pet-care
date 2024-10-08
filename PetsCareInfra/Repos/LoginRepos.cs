﻿using Microsoft.EntityFrameworkCore;
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

        public async Task CreateLogin(Login login)
        {
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();
        }

        public async Task<Login> GetLoginByEmail(string email)
        {
            var login = await (from l in _context.Logins
                               join u in _context.Users on l.UserId equals u.Id
                               where u.Email == email
                               select l).FirstOrDefaultAsync();
            return login;
        }

        public async Task<Login> GetLoginByUserId(int userId)
        {

            return await _context.Logins.FirstOrDefaultAsync(l => l.UserId == userId);
        }

        public async Task UpdateLogin(Login login)
        {
            _context.Logins.Update(login);
            await _context.SaveChangesAsync();
        }
    }
}
