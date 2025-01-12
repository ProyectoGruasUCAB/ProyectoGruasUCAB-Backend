
//using System.Net.Mail;

namespace API_GruasUCAB.Auth.Infrastructure.Validators.Email
{
     public class EmailService : IService<EmailRequestDTO, EmailResponseDTO>
     {
          private readonly SmtpClientFactory _smtpClientFactory;

          public EmailService(SmtpClientFactory smtpClientFactory)
          {
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