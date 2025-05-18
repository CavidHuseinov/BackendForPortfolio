
namespace Portfolio.Business.Helpers.DTOs.Common
{
    public abstract record BaseDto
    {
        public Guid Id { get; set; }    
        public string CreatedAt { get; set; } = default!;
    }
}
