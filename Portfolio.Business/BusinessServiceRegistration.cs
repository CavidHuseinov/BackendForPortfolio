
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Business.Helpers.Mapper;
using Portfolio.Business.Services.Implementations;
using Portfolio.Business.Services.Interfaces;

namespace Portfolio.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMemoryCache();
        }
        public static void DIServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IReviewService,ReviewService>();
        }
    }
}
