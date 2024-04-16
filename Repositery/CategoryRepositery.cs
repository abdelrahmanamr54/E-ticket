using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Repositery
{
   

    public class CategoryRepositery : I_CategoryRepositery
    {

        ApplicationDbContext Context = new ApplicationDbContext();
        public List<Category> GetCategories()
        {
            var category = Context.categories.ToList();


            return category;
        }
        public List<Movie> CategoryDetails(int id)
        {
            var categorymovies = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Where(e => e.CategoryId == id).ToList();


            return categorymovies;
        }
    }
}
