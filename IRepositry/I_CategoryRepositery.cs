using E_ticket.Models;

namespace E_ticket.IRepositry
{
    public interface I_CategoryRepositery
    {
        public List<Category> GetCategories();

        public List<Movie> CategoryDetails(int id);
    }
}
//I_AdminRepositery
//AdminRepositery