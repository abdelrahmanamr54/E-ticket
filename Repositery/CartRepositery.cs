using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Repositery
{
    public class CartRepositery : I_CartRepositery
    {
        ApplicationDbContext Context = new ApplicationDbContext();


        public Cart cart;
        private readonly IEmailSender _emailSender;
        //public CartController(IEmailSender emailSender)
        //{
 
        //}
        //public CartController(IEmailSender emailSender)

        //{
        //    this._emailSender = emailSender;
        //    cart = new Cart();
        //}
        public Movie Add_movie(int id)
        {
            var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Single(e => e.Id == id);


            return movie;
        }



        public void AddMovieToCart(int id, int quantity)
        {




            //var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Single(e => e.Id==id);
            //if (movie != null)
            //{
            //    // Add the movie to the cart
            //    cart.movies.Add(movie);
            //}

            //var selectedmovie = new List<Item>();

            //var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Single(e => e.Id == id);

            //selectedmovie.Add(new Item()
            //{
            //    movie = movie,
            //    Quantity = 1
            //});
            var movie = Context.movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.actors).Single(e => e.Id == id);

            var add = Context.items.Add(new Item() { movie = movie, Quantity = quantity });
            Context.SaveChanges();

            //cart.movies.Add(movie);
            //TempData["note"] = selectedmovie;
            //return RedirectToAction( "Index", "Movies");
          //  return  add;
        }
        public List<Item> GetAllCartItems()
        {

            var itemlist = Context.items.Include(e => e.movie).Include(e => e.movie.Cinema).ToList();
          //  double totalPrice = itemlist.Sum(item => item.movie.Price * item.Quantity);
           // ViewBag.TotalPrice = totalPrice;


            return   itemlist;
        }
        public void DeleteItem(int id)
        {
            var selectedtask = Context.items.Single(e => e.Id == id);
            if (selectedtask is not null)

            {
                Context.items.Remove(selectedtask);
                Context.SaveChanges();
            }
            //return RedirectToAction("cartt");
        }
    }
}
