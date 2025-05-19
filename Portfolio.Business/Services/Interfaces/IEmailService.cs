
namespace Portfolio.Business.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string fullName,string toEmail, string subject, string body);
    }
}
