
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Portfolio.Business.Helpers.DTOs.Blog;
using Portfolio.Business.Services.Interfaces;
using Portfolio.Core.Entities;
using Portfolio.DAL.Repositories.Interfaces;
using Portfolio.DAL.Repositories.Interfaces.Generics;
using Portfolio.DAL.UnitOfWorks;

namespace Portfolio.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _mapper;
        private readonly IQueryRepo<Blog> _query;
        private readonly IBlogRepo _command;
        private readonly IUnitOfWork _save;
        private readonly IMemoryCache _memory;
        private readonly string cacheKey = "BlogCacheAndReviewCache";
        public BlogService(IMapper mapper, IQueryRepo<Blog> query, IBlogRepo command, IUnitOfWork save, IMemoryCache memory)
        {
            _mapper = mapper;
            _query = query;
            _command = command;
            _save = save;
            _memory = memory;
        }

        public async Task<BlogDto> CreateAsync(CreateBlogDto dto)
        {
            var data = _mapper.Map<Blog>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(cacheKey, newData);
            return _mapper.Map<BlogDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException($"Blog tapilmadi {id}");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Remove(cacheKey);
        }

        public async Task<ICollection<BlogDto>> GetAllAsync()
        {
            if (_memory.TryGetValue(cacheKey, out ICollection<Blog>? cachedDict))
            {
                return _mapper.Map<ICollection<BlogDto>>(cachedDict);
            }

            var allData = await _query.GetAllAsync(
                include: q => q.Include(x => x.Reviews.OrderByDescending(x=>x.CreatedAt.Date)),
                orderBy: q => q.OrderByDescending(x => x.CreatedAt.Date)
            ).ToListAsync();

            var mappedData = _mapper.Map<ICollection<BlogDto>>(allData);

            _memory.Set(cacheKey, mappedData);
            return mappedData;
        }


        public async Task<BlogDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException($"Blog tapilmadi {id}");
            return _mapper.Map<BlogDto>(dataId);
        }
    }
}
