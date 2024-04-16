using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using E_ticket.Repositery;
using E_ticket.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Controllers
{
    [Authorize (Roles ="Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        I_AdminRepositery adminRepositery = new AdminRepositery();
        public IActionResult add()
        {

            return View();
        }
        public IActionResult add_category(CategoryVM categoryVM)
        {
            
            adminRepositery.GetNewCatagory(categoryVM);

            return View("add");

        }
        public IActionResult addMovie()
        {
            var categories = Context.categories.ToList();
            ViewBag.Categories = categories;
            var cinemas = Context.cinemas.ToList();
            ViewBag.cinemas = cinemas;
            return View();
        }
      



     
        public MovieStatus GetMovieStatus(DateTime StartDate, DateTime EndDate)
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime < StartDate)
            {
                return MovieStatus.Upcoming;
            }
            else if (currentTime >= StartDate && currentTime <= EndDate)
            {
                return MovieStatus.Available;
            }
            else
            {
                return MovieStatus.Expired;
            }
        }



        public IActionResult add_Movie(MovieVM movieVM)
        {
           
            adminRepositery.add_New_Movie( movieVM);
            return View("add");

        }
        [HttpGet]
        public IActionResult editMovie(int id)
        {
            var movie = adminRepositery.editMovie(id);
            var categories = Context.categories.ToList();
            ViewBag.Categories = categories;
            var cinemas = Context.cinemas.ToList();
            ViewBag.cinemas = cinemas;
            return View(movie);
                }

        [HttpPost]
       
        public IActionResult editMovie(MovieVM movie)
        {
        


            //}
            adminRepositery.EditMovie(movie);
            return RedirectToAction("Index", "Home");
        }
    }
}
