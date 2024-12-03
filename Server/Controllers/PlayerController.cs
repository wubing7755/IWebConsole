using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class PlayerController:Controller
    {
        //
        // GET: Player/
        public IActionResult Index()
        {
            return View();
        }
    }
}
