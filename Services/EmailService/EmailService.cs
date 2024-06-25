using System.Net;
using System.Net.Mail;

namespace PortfolioBackend.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        private readonly string _recipient;

        private readonly ILogger<IEmailService> _emailServiceLogger;

        public EmailService(IConfiguration configuration,ILogger<IEmailService> emailServiceLogger)
        {
            _host = Environment.GetEnvironmentVariable("EMAIL_HOST");
            _port = int.Parse(Environment.GetEnvironmentVariable("EMAIL_PORT"));
            _username = Environment.GetEnvironmentVariable("EMAIL_USERNAME");
            _password = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
            _recipient = Environment.GetEnvironmentVariable("EMAIL_RECIPIENT");

            _emailServiceLogger = emailServiceLogger; 
        }

        public async Task<bool> SendEmailAsync(string senderName, string senderEmail, string message)
        {
            try
            {
                using (var client = new SmtpClient(_host, _port))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_username, _password);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_username),
                        Subject = "New Contact Form Submission",
                        Body = $"<h1>Contact Form Submission</h1><p><strong>Name:</strong> {senderName}</p><p><strong>Email:</strong> {senderEmail}</p><p><strong>Message:</strong><br/>{message}</p>",
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(_recipient);

                    await client.SendMailAsync(mailMessage);

                    _emailServiceLogger.LogInformation("Message sent succesfully");

                    return true;
                }
            }
            catch (Exception ex)
            {
                _emailServiceLogger.LogError($"Error sending email: {ex.Message}");
                return false;
            }
        }
    }
}
