

using Portfolio.DAL.Context;

namespace Portfolio.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioDbContext _context;

        public UnitOfWork(PortfolioDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
