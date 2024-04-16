using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Repositery
{ 

 

    public class MoviesRepositery : I_MoviesRepositery
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        public List<Models.Movie> GetAll()
        {
            var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).ToList();


            return movie;
        }

        public Models.Movie GetById(int id)
        {
            var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Single(e => e.Id == id);

            Movie viewModel = new Movie
            {
                //Title = movie.Title,
                //ReleaseDate = movie.ReleaseDate,
                //ExpiryDate = movie.ExpiryDate,
                //Status = GetMovieStatus(movie.ReleaseDate, movie.ExpiryDate),
                actors = movie.actors.Select(a => new Actor { ProfilePicture = a.ProfilePicture }).ToList()
            };
            movie.Count++;
            Context.SaveChanges();

            return movie;
        }
        public List<Models.Movie> search(string name)
        {
            //var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Where(e => e.Name == name).ToList();
            var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Where(e => e.Name.Contains(name)).ToList();

            return movie;
        }

    }
}
