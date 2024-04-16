using E_ticket.Models;

namespace E_ticket.IRepositry
{
    public interface I_CinemaRepositery
    {

        public List<Cinema> GetAllCinema();
       
        public List<Movie> GetCinemaDetails(int id);
    }
}
