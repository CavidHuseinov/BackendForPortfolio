
using Portfolio.Core.ValudObjects;

namespace Portfolio.Business.Helpers.DTOs.Common
{
    public record BaseDto
    {
        public Guid Id { get; set; }    
        public string CreatedAt { get; set; } = default!;
    }
}
