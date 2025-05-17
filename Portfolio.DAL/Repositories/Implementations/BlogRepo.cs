
using Portfolio.Core.Entities;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repositories.Implementations.Generics;
using Portfolio.DAL.Repositories.Interfaces;

namespace Portfolio.DAL.Repositories.Implementations
{
    public class BlogRepo : CommandRepo<Blog>, IBlogRepo
    {
        public BlogRepo(PortfolioDbContext context) : base(context)
        {
        }
    }
}
