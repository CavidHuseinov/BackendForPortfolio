
using Portfolio.Business;
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
            BusinessServiceRegistration.AddBusiness(builder.Services);
            BusinessServiceRegistration.DIServices(builder.Services);


            var app = builder.Build();
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
