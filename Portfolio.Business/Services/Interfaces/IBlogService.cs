
using Portfolio.Business.Helpers.DTOs.Blog;

namespace Portfolio.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task<ICollection<BlogDto>> GetAllAsync();
        Task<BlogDto> GetByIdAsync(Guid id);
        Task<BlogDto> CreateAsync(CreateBlogDto dto);
        Task DeleteAsync(Guid id);
    }
}
