
using Portfolio.Business.Helpers.DTOs.Review;

namespace Portfolio.Business.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ICollection<ReviewDto>> GetAllAsync();
        Task<ReviewDto> CreateAsync(CreateReviewDto dto);
        Task<ReviewDto> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);  
    }
}
