using Microsoft.EntityFrameworkCore;
using Model;

namespace Server.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var basePath = Directory.GetCurrentDirectory();
            var dbPath = Path.Combine(basePath, "Database", "IWebDatabase.db");

            optionsBuilder.UseSqlite($"FileName={dbPath}");
        }
    }
}
