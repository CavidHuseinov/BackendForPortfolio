
using Amazon.S3;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Business.Helpers.Mapper;
using Portfolio.Business.Services.Implementations;
using Portfolio.Business.Services.Interfaces;
using System.Reflection;

namespace Portfolio.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusiness(this IServiceCollection services,IConfiguration config)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMemoryCache();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddDefaultAWSOptions(config.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
        }
        public static void DIServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IReviewService,ReviewService>();
            services.AddScoped<IAWSImageService,AWSImageService>();
        }
    }
}
