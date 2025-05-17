
using Portfolio.Business.Helpers.DTOs.Common;

namespace Portfolio.Business.Helpers.DTOs.Blog
{
    public record BlogDto:BaseDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImgUrl { get; set; }
    }
}
