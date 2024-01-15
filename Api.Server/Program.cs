using Database;
using Microsoft.EntityFrameworkCore;

namespace Api.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseOrleansClient(client => { client.UseLocalhostClustering(); }).ConfigureLogging(logging => logging.AddConsole());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMyDatabaseService(builder.Configuration);

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            UpdateMigrateDatabase(app);

            app.Run();
        }

        public static void UpdateMigrateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MyDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
