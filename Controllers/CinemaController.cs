using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using E_ticket.Repositery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Controllers
{
    public class CinemaController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        I_CinemaRepositery cinemaRepositery = new CinemaRepositery();
        public IActionResult Index()
        {
            var cinema = cinemaRepositery.GetAllCinema();


            return View(cinema);
        }
        public IActionResult CinemaDetails(int id)
        {
            var cinemamovies = cinemaRepositery.GetCinemaDetails(id);


            return View( cinemamovies);
        }
    }
}
