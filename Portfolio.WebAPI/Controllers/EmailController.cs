using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Helpers.DTOs.Email;
using Portfolio.Business.Services.Interfaces;

namespace Portfolio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitComment([FromForm] CreateEmailDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Rəyiniz göndərilmədi");
            }

            try
            {
                string body = $"İstifadəçi: {model.FullName},bu email ile:({model.Email})\n\nBasliq:{model.Subject} Rəy gonderdi: {model.Comment}";
                await _emailService.SendEmailAsync(model.FullName, "cv@cavidhuseynov.me", model.Subject, body);
                return Ok("Rəy uğurla göndərildi.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
