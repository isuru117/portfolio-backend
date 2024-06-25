using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.Models;
using PortfolioBackend.Services;

namespace PortfolioBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactMeController : ControllerBase
    {
        private readonly ILogger<ContactMeController> _contactMelogger;
        private readonly IEmailService _emailService;

        public ContactMeController(ILogger<ContactMeController> contactMeLogger, IEmailService emailService)
        {
            _contactMelogger = contactMeLogger;
            _emailService = emailService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(ContactRequestModel contactRequest)
        {
            if (contactRequest == null)
            {
                return BadRequest("Invalid data.");
            }

            if (string.IsNullOrWhiteSpace(contactRequest.Name) ||
                string.IsNullOrWhiteSpace(contactRequest.Email))
            {
                return BadRequest("Name and Email are required.");
            }

            try
            {
                await _emailService.SendEmailAsync(contactRequest.Name, contactRequest.Email, contactRequest.Message);
                return Ok("Your message has been received.");
            }
            catch (Exception ex)
            {
                _contactMelogger.LogError(ex, "Error sending email");
                return StatusCode(500, "An error occurred while sending your message.");
            }
        }
    }
}
