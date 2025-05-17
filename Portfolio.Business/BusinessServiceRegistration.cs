
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Business.Helpers.Mapper;
using Portfolio.Business.Services.Implementations;
using Portfolio.Business.Services.Interfaces;
using System.Reflection;

namespace Portfolio.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMemoryCache();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public static void DIServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IReviewService,ReviewService>();
            services.AddScoped<IAWSImageService,AWSImageService>();
        }
    }
}
