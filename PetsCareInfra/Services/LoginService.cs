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
        private readonly IUserRepos _userRepository;
        private readonly IEmailSender _emailSender;

        public LoginService(IloginRepos loginRepository, IUserRepos userRepository, IEmailSender emailSender)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _emailSender = emailSender;
        }
        public async Task<bool> RecoverPassword(RecoverPasswordDTO recoverPasswordDTO)
        {
            var user = await _userRepository.GetUserByEmail(recoverPasswordDTO.Email);
            if (user == null)
            {
                return false;
            }

            var token = Guid.NewGuid().ToString();
            await _userRepository.SetPasswordResetToken(user, token, DateTime.Now.AddHours(1));

            var callbackUrl = $"https://yourdomain.com/User/ResetPassword?token={token}";
            await _emailSender.SendEmailAsync(user.Email, "Reset Password",
                $"Please reset your password by clicking <a href='{callbackUrl}'>here</a>");

            return true;
        }

        public async Task<bool> SignIn(LoginDTO loginDTO)
        {
            var login = await _loginRepository.GetLoginByEmail(loginDTO.Email);
            if (login == null || login.Password != loginDTO.Password)
            {
                return false;
            }
            login.IsLoggedIn = true;
            login.LastLoginTime = DateTime.Now;
            await _loginRepository.UpdateLogin(login);
            return true;
        }
        public async Task<bool> SignOut(int userId)
        {
            var login = await _loginRepository.GetLoginByUserId(userId);
            if (login == null)
            {
                return false;
            }
            login.IsLoggedIn = false;
            await _loginRepository.UpdateLogin(login);
            return true;
        }
    }
}
