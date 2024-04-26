using Persistance;
using Notes.Application;
using Application.Common.Mappings;
using System.Reflection;
using Application.Interfaces;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
                    DbInitialize.Initialize(context);
                }
                catch (Exception exception)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAutoMapper(typeof(Program));

                    services.AddPersistance(hostContext.Configuration);
                    services.AddControllers();

                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowAll", policy =>
                        {
                            policy.AllowAnyHeader();
                            policy.AllowAnyMethod();
                            policy.AllowAnyOrigin();
                        });
                    });
                });
    }
}
