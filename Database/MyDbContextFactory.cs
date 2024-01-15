using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Database
{
    public class MyUsersDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var str = "Host=localhost;Database=orlians_db;Username=postgres;Password=1;Pooling=true;";
            var options = new DbContextOptionsBuilder<MyDbContext>();
            options.UseNpgsql(str)
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();

            return new MyDbContext(options.Options);
        }
    }
}
