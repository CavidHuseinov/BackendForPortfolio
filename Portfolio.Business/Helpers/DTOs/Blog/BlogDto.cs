
using Portfolio.Business.Helpers.DTOs.Common;
using Portfolio.Business.Helpers.DTOs.Review;

namespace Portfolio.Business.Helpers.DTOs.Blog
{
    public record BlogDto:BaseDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImgUrl { get; set; }
        public ICollection<ReviewDto>? Reviews { get; set; }
    }
}
