using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using E_ticket.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Repositery
{
    public class AdminRepositery : I_AdminRepositery
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        public void GetNewCatagory(CategoryVM categoryVM)
        {
            var newcatagerory = Context.categories.Add(new Models.Category { Name = categoryVM.Name });
            Context.SaveChanges();

           // return View("add", newcatagerory);

        }
        public void GetNewMovie()
        {
            var categories = Context.categories.ToList();
           // ViewBag.Categories = categories;
            var cinemas = Context.cinemas.ToList();
           // ViewBag.cinemas = cinemas;
            //return View();
        }
        public void add_New_Movie(MovieVM movieVM)
        {
            // DateTime StartDate = new DateTime(2024, 4, 1);
            // DateTime EndDate = new DateTime(2024, 12, 31);
            MovieStatus status = GetMovieStatus(movieVM.StartDate, movieVM.EndDate);
            var newmovie = Context.movies.Add(new Models.Movie { Name = movieVM.Name, Description = movieVM.Description, Price = movieVM.Price, ImgUrl = movieVM.ImgUrl, TrailerUrl = movieVM.TrailerUrl, StartDate = movieVM.StartDate, EndDate = movieVM.EndDate, CinemaId = movieVM.CinemaId, CategoryId = movieVM.CategoryId, movieStatus = status });
            Context.SaveChanges();

            var categories = Context.categories.ToList();
           // ViewBag.Categories = categories;
           // return View("add_Movie", newmovie);

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
        public Movie editMovie(int id)
        {
            var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Single(e => e.Id == id);
          //  var categories = Context.categories.ToList();
           
            return movie;
        }

        public void EditMovie(MovieVM movie)
        {
            var selectedmovie = Context.movies.Find(movie.Id);
            //var selectedmovie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Single(e => e.Id == movie.Id);
            DateTime StartDate = movie.StartDate;
            DateTime EndDate = movie.EndDate;
            MovieStatus status = GetMovieStatus(StartDate, EndDate);

            if (selectedmovie is not null)
            {
                selectedmovie.Name = movie.Name;
                selectedmovie.Description = movie.Description;
                selectedmovie.Price = movie.Price;
                selectedmovie.ImgUrl = movie.ImgUrl;
                selectedmovie.TrailerUrl = movie.TrailerUrl;
                selectedmovie.CinemaId = movie.CinemaId;
                selectedmovie.CategoryId = movie.CategoryId;
                selectedmovie.StartDate = movie.StartDate;
                selectedmovie.EndDate = movie.EndDate;
                selectedmovie.movieStatus = status;
                Context.SaveChanges();


            }
        }
       
    }
}
