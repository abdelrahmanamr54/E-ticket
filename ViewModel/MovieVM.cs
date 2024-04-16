using E_ticket.Models;

namespace E_ticket.ViewModel
{
    using System.ComponentModel.DataAnnotations;
    public class MovieVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }
        public MovieStatus movieStatus { get; set; }
       
        public int Count { get; set; }
    }
}
