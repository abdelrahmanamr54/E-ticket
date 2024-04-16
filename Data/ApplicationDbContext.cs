using E_ticket.Models;
using E_ticket.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_ticket.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

       public DbSet<Movie> movies { get; set; }
        public DbSet<Actor> actors{ get; set; }
        public DbSet<Category> categories{ get; set; }
        public DbSet<Cinema> cinemas { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
        //DbSet<ActorMovie> actorMovies { get; set; }
        //DbSet<MovieStatus> movieStatuses { get; set; }
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build().GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder
                );
        }
    }
}
