using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static class MyDbContextService
    {
        public static void AddMyDatabaseService(this IServiceCollection services, IConfiguration conf)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var connStr = conf.GetConnectionString("DbConnectionString");
            services.AddDbContextPool<MyDbContext>((serviceProvider, o) =>
            {
                o.UseNpgsql(connStr)
                 .UseSnakeCaseNamingConvention()
                 .EnableDetailedErrors()
                 .EnableSensitiveDataLogging();
            });

        }
    }
}
