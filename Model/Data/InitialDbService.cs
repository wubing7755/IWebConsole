using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class InitialDbService
    {
        private readonly DatabaseContext _dbContext;

        public InitialDbService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initial()
        {
            Player player = new Player
            {
                Name = "lihua",
                Description = "definit",
                Grade = Grade.Primary
            };

            _dbContext.Add<Player>(player);

            _dbContext.SaveChanges();
        }
    }
}
