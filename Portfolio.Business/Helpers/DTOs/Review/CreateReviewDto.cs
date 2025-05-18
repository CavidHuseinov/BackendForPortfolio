
namespace Portfolio.Business.Helpers.DTOs.Review
{
    public record CreateReviewDto
    {
        public string Content { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Guid BlogId { get; set; }
    }
}
