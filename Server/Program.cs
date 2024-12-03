using Microsoft.EntityFrameworkCore;
using Model.Data;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            var configuration = builder.Configuration;

            // register DatabaseContext
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("IWebDatabase");
                options.UseSqlite(connectionString);
            });

            builder.Services.AddScoped<InitialDbService>();

            var app = builder.Build();

            // create database
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                dbContext.Database.EnsureCreated();

                var initialDb = scope.ServiceProvider.GetRequiredService<InitialDbService>();
                initialDb.Initial();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}
