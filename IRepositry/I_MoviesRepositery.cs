using E_ticket.Models;

namespace E_ticket.IRepositry
{
    public interface I_MoviesRepositery
    {
        public List<Models.Movie> GetAll();
        
        public Models.Movie GetById(int id);
      
        public List<Models.Movie> search(string name);
    }
}
