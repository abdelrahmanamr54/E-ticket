using System.ComponentModel.DataAnnotations;
namespace E_ticket.ViewModel
{
    public class CinemaVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string CinemaLogo { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
