using System.ComponentModel.DataAnnotations;
namespace E_ticket
    .ViewModel
{
    public class UserRoleVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
