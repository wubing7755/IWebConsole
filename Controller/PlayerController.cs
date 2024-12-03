using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Data;

namespace Controller
{
    public class PlayerController:ControllerBase
    {
        public readonly DatabaseContext _dbContext;
        public PlayerController(DatabaseContext dbContext) { _dbContext = dbContext; }

        //
        // GET: /Player/
        public IActionResult GetPlayer()
        {
            List<Player> players = _dbContext.Player.ToList();

            PlayerVM playerVM = new PlayerVM();

            foreach (var player in players) 
            {
                playerVM.PlayerNames.Add(player.Name);
                playerVM.Players.Add(player);
            }

            return Ok(playerVM);
        }
    }
}
