using E_ticket.Models;

namespace E_ticket.IRepositry
{
    public interface I_CartRepositery
    {
        public Movie Add_movie(int id);
       



        public void AddMovieToCart(int id, int quantity);
      
        public List<Item> GetAllCartItems();
       
        public void DeleteItem(int id);
    }
}
