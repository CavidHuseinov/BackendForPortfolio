
using Portfolio.Business.Helpers.DTOs.Common;

namespace Portfolio.Business.Helpers.DTOs.Review
{
    public record ReviewDto:BaseDto
    {
        public string Content { get; set; } = default!;
    }
}
