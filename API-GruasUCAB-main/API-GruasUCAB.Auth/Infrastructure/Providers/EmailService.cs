using API_GruasUCAB.Auth.Infrastructure.DTOs;
using API_GruasUCAB.Auth.Infrastructure.Response;
using API_GruasUCAB.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace API_GruasUCAB.Auth.Infrastructure.Providers
{
     public class EmailService : IService<EmailRequestDTO, EmailResponseDTO>
     {
          private readonly IConfiguration _configuration;

          public EmailService(IConfiguration configuration)
          {
               _configuration = configuration;
          }

          public async Task<EmailResponseDTO> Execute(EmailRequestDTO emailRequest)
          {
               try
               {
                    var smtpServer = _configuration["EmailSettings:SmtpServer"];
                    var smtpPortString = _configuration["EmailSettings:SmtpPort"];
                    var smtpUsername = _configuration["EmailSettings:SmtpUsername"];
                    var smtpPassword = _configuration["EmailSettings:SmtpPassword"];
                    var fromEmail = _configuration["EmailSettings:FromEmail"];
                    var fromDisplayName = _configuration["EmailSettings:FromDisplayName"];

                    if (string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(smtpPortString) || string.IsNullOrEmpty(smtpUsername) ||
                        string.IsNullOrEmpty(smtpPassword) || string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(fromDisplayName))
                    {
                         // Log missing configuration
                         return new EmailResponseDTO { Success = false, Message = "Missing email configuration" };
                    }

                    if (!int.TryParse(smtpPortString, out var smtpPort))
                    {
                         // Log invalid port configuration
                         return new EmailResponseDTO { Success = false, Message = "Invalid SMTP port configuration" };
                    }

                    using (var smtpClient = new SmtpClient(smtpServer))
                    {
                         smtpClient.Port = smtpPort;
                         smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                         smtpClient.EnableSsl = true;

                         var mailMessage = new MailMessage
                         {
                              From = new MailAddress(fromEmail, fromDisplayName),
                              Subject = emailRequest.Subject,
                              Body = emailRequest.Body,
                              IsBodyHtml = false,
                         };
                         mailMessage.To.Add(emailRequest.ToEmail);

                         await smtpClient.SendMailAsync(mailMessage);
                    }

                    return new EmailResponseDTO { Success = true, Message = "Email sent successfully" };
               }
               catch (Exception ex)
               {
                    // Log the exception (ex)
                    return new EmailResponseDTO { Success = false, Message = $"Error sending email: {ex.Message}" };
               }

          }
     }
}