using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using E_ticket.Repositery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Controllers
{
    public class MoviesController : Controller
    {
       // ApplicationDbContext Context = new ApplicationDbContext();

       // MoviesRepositery moviesRepositery = new MoviesRepositery();
        I_MoviesRepositery moviesRepositery = new MoviesRepositery();


        private readonly ApplicationDbContext context;

        public MoviesController(ApplicationDbContext context)
        {
            this.context = context;

        }
        //public IActionResult viewmodel()
        //{
        //    DateTime StartDate = new DateTime(2023, 11, 1);
        //    DateTime EndDate = new DateTime(2023, 12, 31);
        //    MovieStatus status = GetMovieStatus(StartDate, EndDate);

        //    // var movie = moviesRepositery.GetAll();

        //    var viewModel = new Movie
        //    {
        //       StartDate = StartDate,
        //        EndDate = EndDate,
        //        movieStatus = status
        //    };
        //    return View(viewModel);
        //}
        public IActionResult Index()
        {
           
            var movie = moviesRepositery.GetAll();
            return View(movie);
        }
       
       //public MovieStatus GetMovieStatus(DateTime StartDate, DateTime EndDate)
       // {
       //     DateTime currentTime = DateTime.Now;

       //     if (currentTime < StartDate)
       //     {
       //         return MovieStatus.Upcoming;
       //     }
       //     else if (currentTime >= StartDate && currentTime <= EndDate)
       //     {
       //         return MovieStatus.Available;
       //     }
       //     else
       //     {
       //         return MovieStatus.Expired;
       //     }
       // }
        public IActionResult GtDetails( int id)
        {
           

            var movie = moviesRepositery.GetById(id);
            return View(movie);
        }
        public IActionResult search(string name)
        {
           
            var movie = moviesRepositery.search(name);
            return View("search",movie);
        }


    }
}
