using E_ticket.Data;
using E_ticket.IRepositry;
using E_ticket.Models;
using E_ticket.Repositery;
using Microsoft.AspNetCore.Authorization;
using E_ticket.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace E_ticket.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        I_CartRepositery cartRepositery = new CartRepositery();

         public  Cart cart;
        private readonly IEmailSender _emailSender;
        //public CartController(IEmailSender emailSender)
        //{
           
        //}
        public CartController(IEmailSender emailSender)
            
        {
            this._emailSender = emailSender;
            cart = new Cart();
        }
        public IActionResult Add(int id)
        {
            var movie = cartRepositery.Add_movie(id);


            return View(movie);
        }



        public IActionResult AddToCart(int id,int quantity)
        {




           

            cartRepositery.AddMovieToCart(id,quantity);
           
            return View();
        }
        public IActionResult cartt()
        {

            var itemlist = cartRepositery.GetAllCartItems();
            double totalPrice = itemlist.Sum(item => item.movie.Price*item.Quantity);
        ;
          
            ViewBag.TotalPrice = totalPrice;


            return View(itemlist);
        }
        public IActionResult delete(int id)
        {
           
            cartRepositery.DeleteItem(id);
       
            return RedirectToAction("cartt");
        }
        public async Task<IActionResult> SendEmail()
        {
           
            var MovieEmails = Context.items.Include(e => e.movie).Include(e => e.movie.Cinema).ToList();
           
            var reciver = "abdelrahman.amr188@gmail.com";
            var subject = "Booking Confifrmed!";
            var itemlist = cartRepositery.GetAllCartItems();
            double totalPrice = itemlist.Sum(item => item.movie.Price * item.Quantity);
            ViewBag.TotalPrice = totalPrice;
            StringBuilder bodyBuilder = new StringBuilder();
         
               

                //var message = "HELLO FROM again SMTP";
                foreach (var item in MovieEmails)
            {
                bodyBuilder.AppendLine($"Movie name: {item.movie.Name}, Tickets Quantity: {item.Quantity} Cinema name: {item.movie.Cinema.Name}  "   );
               
            }
            string body = bodyBuilder.ToString() + $"\n\n totalPrice ${ViewBag.TotalPrice}";
         
             await _emailSender.SendEmailAsync(reciver, subject, body);
         

            return RedirectToAction("checkEmail", "Cart");
        }

        public IActionResult checkEmail()
        {
            return View();
        }


    }
}
