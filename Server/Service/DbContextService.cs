using Model;
using Server.Database;

namespace Server.Service
{
    public class DbContextService
    {
        private readonly DatabaseContext _dbContext;

        public DbContextService(DatabaseContext dbContext) { _dbContext = dbContext; }

        public void Add_Player(Player player)
        {
            _dbContext.Players.Add(player);
            _dbContext.SaveChanges();
        }
    }
}
