using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Service;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            // Configure service
            builder.Services.ConfigureServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers(); // Simplified controller route mapping
            app.MapRazorPages();

            // Apply database migrations
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                dbContext.Database.Migrate(); // Apply all pending migrations
            }

            app.Run();
        }
    }

    public static class ServiceConfigurationExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<DatabaseContext>(options =>
            //    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddEntityFrameworkSqlite().AddDbContext<DatabaseContext>();

            services.AddScoped<DbContextService>();
        }
    }
}
