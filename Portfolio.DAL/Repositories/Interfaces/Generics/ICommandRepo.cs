
using Portfolio.Core.Entities.Common;

namespace Portfolio.DAL.Repositories.Interfaces.Generics
{
    public interface ICommandRepo<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
