using System.ComponentModel.DataAnnotations;

namespace E_ticket
    .ViewModel
{
    public class ApplicationUserVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [RegularExpression("Cairo|Alex|Mansoura")]
        public string Address { get; set; }
    }
}
