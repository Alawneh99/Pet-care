using PetsCareCore.DTOs.Login;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using PetsCareInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsCareInfra.Services
{
    public class LoginService : ILoginService
    {
        private readonly IloginRepos _loginRepository;

        public LoginService(IloginRepos loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<bool> RecoverPassword(RecoverPasswordDTO recoverPasswordDTO)
        {
            var login = await _loginRepository.GetLoginByUserName(recoverPasswordDTO.Email);
            if (login == null)
            {
                return false; 
            } 
            return true;
        }

        public async Task<bool> SignIn(LoginDTO loginDTO)
        {
            var login = await _loginRepository.GetLoginByUserName(loginDTO.Email);
            if (login == null || login.Password != loginDTO.Password)
            {
                return false; 
            }
            return true; 
        }
        public async Task<bool> SignOut(int userId)
        {
            return true;
        }
    }
}
