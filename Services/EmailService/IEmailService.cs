namespace PortfolioBackend.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string senderName, string senderEmail, string message);
    }
}