
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.DAL.Context;
using Portfolio.DAL.Repositories.Implementations;
using Portfolio.DAL.Repositories.Implementations.Generics;
using Portfolio.DAL.Repositories.Interfaces;
using Portfolio.DAL.Repositories.Interfaces.Generics;
using Portfolio.DAL.UnitOfWorks;

namespace Portfolio.DAL
{
    public static class DALServiceRegistration
    {
        public static void AddDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<PortfolioDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Deploy"));
            });
        }
        public static void DIRepository (this IServiceCollection services)
        {
            #region Generics
            services.AddScoped(typeof(ICommandRepo<>), typeof(CommandRepo<>));
            services.AddScoped(typeof(IQueryRepo<>), typeof(QueryRepo<>));
            #endregion

            #region UnitOfWorks
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            #endregion

            #region Repositories
            services.AddScoped<IBlogRepo,BlogRepo>();
            services.AddScoped<IReviewRepo,ReviewRepo>();
            #endregion
        }
    }
}
