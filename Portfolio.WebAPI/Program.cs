
using Portfolio.Business;
using Portfolio.Core.Settings;
using Portfolio.DAL;

namespace Portfolio.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            DALServiceRegistration.AddDAL(builder.Services, builder.Configuration);
            DALServiceRegistration.DIRepository(builder.Services);
            BusinessServiceRegistration.AddBusiness(builder.Services, builder.Configuration);
            BusinessServiceRegistration.DIServices(builder.Services);
            builder.Services.Configure<AmazonSettings>(builder.Configuration.GetSection("AmazonSettings"));
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
             

            var app = builder.Build();
            app.UseCors("AllowAll");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
