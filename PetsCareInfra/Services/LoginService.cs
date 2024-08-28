using PetsCareCore.DTOs.Login;
using PetsCareCore.Repos;
using PetsCareCore.Services;
using PetsCareInfra.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PetsCareCore.Helper;
using Microsoft.Extensions.Configuration;
using PetsCareCore.Models.Entities;

namespace PetsCareInfra.Services
{
    public class LoginService : ILoginService
    {
        private readonly IloginRepos _loginRepository;
        private readonly IUserRepos _userRepository;
        private readonly IConfiguration _configuration;


        public LoginService(IloginRepos loginRepository, IUserRepos userRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _configuration = configuration;
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

            await SendOtpViaEmail(user.Email, token);

            return true;
        }

        public async Task<bool> ResetPassword(string email, string token, string newPassword)
        {
            
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null || user.ResetPasswordToken != token || user.ResetPasswordExpiry < DateTime.Now)
            {
                return false; 
            }

            
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

          
            var login = await _loginRepository.GetLoginByEmail(email);
            if (login == null)
            {
                return false; 
            }

            login.Password = newPassword;

            
            await _userRepository.UpdateUser(user);
            await _loginRepository.UpdateLogin(login);

            
            user.ResetPasswordToken = null;
            user.ResetPasswordExpiry = null;
            await _userRepository.UpdateUser(user);

            return true; 

        }

        public async Task SendOtpViaEmail(string email, string code)
        {
            
            MailMessage message = new MailMessage();

            
            message.Subject = "Verification Code";
            message.Body = "Use this Following Code  \n " + code + "\nto Confirm Your Operation. Kindly remember it's valid for 4 minutes since now.";
            message.From = new MailAddress("PetsCare8899@outlook.com", "Pets Care"); 

            
            message.To.Add(new MailAddress(email, "Recipient 1")); 

            
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.office365.com",
                Port = 587,
                Credentials = new NetworkCredential("PetsCare8899@outlook.com", "Osa&1234"),
                EnableSsl = true,
            };

            try
            {
                
                 await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }
        public async Task<(string token, int userId)> SignIn(LoginDTO loginDTO)
        {
            
            var user = await _userRepository.GetUserByEmail(loginDTO.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash))
            {
                
                return (null,0);
            }

            
            var userRole = await _userRepository.GetUserRole(user.UserRoleID);
            if (userRole == null)
            {
                
                return (null,0); 
            }

            
            var secret = _configuration.GetValue<string>("JwtConfig:Secret");

            
            var token = TokenHelper.GenerateJwtToken(user.Email, userRole.RoleName, secret);
            return (token, user.Id);

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
