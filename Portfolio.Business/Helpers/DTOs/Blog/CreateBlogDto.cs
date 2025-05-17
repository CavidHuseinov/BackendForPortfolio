
namespace Portfolio.Business.Helpers.DTOs.Blog
{
    public record CreateBlogDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImgUrl { get; set; }
    }
}
