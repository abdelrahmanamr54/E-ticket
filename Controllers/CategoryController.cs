using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Repositery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        I_CategoryRepositery categoryRepositery = new CategoryRepositery();
        public IActionResult Index()
        {
            var category = categoryRepositery.GetCategories();


            return View(category);
        }
        public IActionResult Details( int id)
        {
            var categorymovies = categoryRepositery.CategoryDetails(id);
         

            return View(categorymovies);
        }

    }
}
