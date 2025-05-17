
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Business.Helpers.DTOs.Blog;
using Portfolio.Business.Helpers.DTOs.Review;
using Portfolio.Business.Services.Interfaces;
using Portfolio.Core.Entities;
using Portfolio.DAL.Repositories.Interfaces;
using Portfolio.DAL.Repositories.Interfaces.Generics;
using Portfolio.DAL.UnitOfWorks;

namespace Portfolio.Business.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IQueryRepo<Review> _query;
        private readonly IReviewRepo _command;
        private readonly IUnitOfWork _save;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memory;
        private readonly string cacheKey = "BlogCacheAndReviewCache";

        public ReviewService(IQueryRepo<Review> query, IReviewRepo command, IUnitOfWork save, IMapper mapper, IMemoryCache memory)
        {
            _query = query;
            _command = command;
            _save = save;
            _mapper = mapper;
            _memory = memory;
        }

        public async Task<ReviewDto> CreateAsync(CreateReviewDto dto)
        {
            var data = _mapper.Map<Review>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(cacheKey, newData);
            return _mapper.Map<ReviewDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException($"Blog tapilmadi {id}");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Remove(dataId);
        }

        public async Task<ICollection<ReviewDto>> GetAllAsync()
        {
            if (_memory.TryGetValue(cacheKey, out ICollection<Review>? cachedDict))
            {
                return _mapper.Map<ICollection<ReviewDto>>(cachedDict);
            }
            var allData = await _query.GetAllAsync().ToListAsync();
            var mappedData = _mapper.Map<ICollection<ReviewDto>>(allData);
            _memory.Set(cacheKey, mappedData);
            return mappedData;
        }

        public async Task<ReviewDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException($"Blog tapilmadi {id}");
            return _mapper.Map<ReviewDto>(dataId);
        }
    }
}
