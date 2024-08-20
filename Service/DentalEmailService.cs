using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace dentalApi.Service
{
    namespace dentalApi.Service
    {
        public class DentalEmailService
        {
            private readonly IConfiguration _configuration;

            public DentalEmailService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task SendEmailAsync(string toEmail, string subject, string body)
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(
                    _configuration["SmtpSettings:SenderName"],
                    _configuration["SmtpSettings:SenderEmail"]
                ));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(
                    _configuration["SmtpSettings:Server"],
                    int.Parse(_configuration["SmtpSettings:Port"]),
                    false
                );
                await smtp.AuthenticateAsync(
                    _configuration["SmtpSettings:Username"],
                    _configuration["SmtpSettings:Password"]
                );
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
        }
    }

}
