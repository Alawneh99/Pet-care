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

namespace PetsCareInfra.Services
{
    public class LoginService : ILoginService
    {
        private readonly IloginRepos _loginRepository;
        private readonly IUserRepos _userRepository;
        

        public LoginService(IloginRepos loginRepository, IUserRepos userRepository)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            
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

            SendOtpViaEmail(user.Email, token);

            return true;
        }
        public async Task SendOtpViaEmail(string email, string code)
        {
            // Create a new instance of MailMessage class
            MailMessage message = new MailMessage();

            // Set subject of the message, body and sender information
            message.Subject = "Verification Code";
            message.Body = "Use this Following Code  \n " + code + "\nto Confirm Your Operation. Kindly remember it's valid for 4 minutes since now.";
            message.From = new MailAddress("PetsCare8899@outlook.com", "Pets Care"); // Remove the third parameter

            // Add To recipients
            message.To.Add(new MailAddress(email, "Recipient 1")); // Remove the third parameter

            // Create an instance of SmtpClient class
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.office365.com",
                Port = 587,
                Credentials = new NetworkCredential("PetsCare8899@outlook.com", "Osa&1234"),
                EnableSsl = true,
            };

            try
            {
                // Send this email
                 await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
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
