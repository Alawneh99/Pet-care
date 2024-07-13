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

            SendOtpViaEmail(user.Email, token);

            return true;
        }

        public async Task<bool> ResetPassword(string email, string token, string newPassword)
        {
            // Retrieve the user entity by email
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null || user.ResetPasswordToken != token || user.ResetPasswordExpiry < DateTime.Now)
            {
                return false; // Invalid or expired token
            }

            // Update the hashed password in the user entity
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // Update the password in the login entity (plaintext)
            var login = await _loginRepository.GetLoginByEmail(email);
            if (login == null)
            {
                return false; // Handle scenario where login entity doesn't exist for the user
            }

            login.Password = newPassword;

            // Update both entities in the database
            await _userRepository.UpdateUser(user);
            await _loginRepository.UpdateLogin(login);

            // Clear reset password fields in the user entity
            user.ResetPasswordToken = null;
            user.ResetPasswordExpiry = null;
            await _userRepository.UpdateUser(user);

            return true; // Password reset successfully

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
        public async Task<string> SignIn(LoginDTO loginDTO)
        {
            // Fetch the user by email
            var user = await _userRepository.GetUserByEmail(loginDTO.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash))
            {
                // Return null or appropriate message if authentication fails
                return null; // Incorrect credentials
            }

            // Fetch user role based on UserRoleID assumed to be part of the User entity
            var userRole = await _userRepository.GetUserRole(user.UserRoleID);
            if (userRole == null)
            {
                // Return null or appropriate error message if no role found
                return null; // Role information is mandatory
            }

            // Retrieve secret key from configuration
            var secret = _configuration.GetValue<string>("JwtConfig:Secret");

            // Generate JWT token with email and role
            var token = TokenHelper.GenerateJwtToken(user.Email, userRole.RoleName, secret);
            return token;

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
