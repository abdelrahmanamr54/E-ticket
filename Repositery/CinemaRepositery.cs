using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Repositery
{
    public class CinemaRepositery : I_CinemaRepositery
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        public List<Cinema> GetAllCinema()
        {
            var cinema = Context.cinemas.ToList();


            return cinema;
        }
        public List<Movie> GetCinemaDetails(int id)
        {
            var cinemamovies = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Where(e => e.CinemaId == id).ToList();


            return cinemamovies;
        }
    }
}
