
using Microsoft.EntityFrameworkCore.Query;
using Portfolio.Core.Entities.Common;
using System.Linq.Expressions;

namespace Portfolio.DAL.Repositories.Interfaces.Generics
{
    public interface IQueryRepo<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true);
        IQueryable<TEntity> GetByPagedAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true,
            int pageIndex = 1,
            int pageSize = 10);
    }
}
