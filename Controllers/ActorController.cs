using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Repositery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_ticket.Controllers
{
    [Authorize]
    public class ActorController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        I_ActorRepositery ActorRepositery = new ActorRepositery();
        public IActionResult ActorDetails(int id)
        {

            var selectedactor = ActorRepositery.ActorDetails(id);
                ;


            return View(selectedactor);
        }
    }
}
