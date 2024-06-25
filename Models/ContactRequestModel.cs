namespace PortfolioBackend.Models
{
    public class ContactRequestModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Message { get; set; }
    }
}
