using API_GruasUCAB.Auth.Infrastructure.Adapters.Email;
using API_GruasUCAB.Auth.Infrastructure.DTOs.Email;
using API_GruasUCAB.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Mail;
using System;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.Email
{
     public class EmailService : IService<EmailRequestDTO, EmailResponseDTO>
     {
          private readonly IConfiguration _configuration;
          private readonly EmailTemplateService _emailTemplateService;
          private readonly SmtpClientFactory _smtpClientFactory;

          public EmailService(IConfiguration configuration, EmailTemplateService emailTemplateService, SmtpClientFactory smtpClientFactory)
          {
               _configuration = configuration;
               _emailTemplateService = emailTemplateService;
               _smtpClientFactory = smtpClientFactory;
          }

          public async Task<EmailResponseDTO> Execute(EmailRequestDTO emailRequest)
          {
               try
               {
                    var emailSettings = _smtpClientFactory.GetEmailSettings();
                    _smtpClientFactory.ValidateEmailSettings(emailSettings);

                    using (var smtpClient = _smtpClientFactory.CreateSmtpClient(emailSettings))
                    {
                         var mailMessage = _smtpClientFactory.CreateMailMessage(emailRequest, emailSettings);
                         await smtpClient.SendMailAsync(mailMessage);
                    }

                    return new EmailResponseDTO { Success = true, Message = "Email sent successfully", Time = DateTime.UtcNow };
               }
               catch (Exception ex)
               {
                    // Log the exception (ex)
                    return new EmailResponseDTO { Success = false, Message = $"Error sending email: {ex.Message}", Time = DateTime.UtcNow };
               }
          }
     }
}