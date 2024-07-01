using Microsoft.Extensions.Configuration;
using PetsCareCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;

namespace PetsCareInfra.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"])
                {
                    Port = int.Parse(_configuration["EmailSettings:SmtpPort"]),
                    Credentials = new NetworkCredential(_configuration["EmailSettings:UserName"], _configuration["EmailSettings:Password"]),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailSettings:From"]),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                _logger.LogInformation($"Sending email to {email}");

                await smtpClient.SendMailAsync(mailMessage);

                _logger.LogInformation($"Email sent to {email}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email to {email}: {ex.Message}");
                throw;
            }
        }
    }
}
