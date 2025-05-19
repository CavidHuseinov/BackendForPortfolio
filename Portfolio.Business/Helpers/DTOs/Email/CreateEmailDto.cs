
namespace Portfolio.Business.Helpers.DTOs.Email
{
    public record CreateEmailDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }

    }
}
