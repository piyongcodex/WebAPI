using System.ComponentModel.DataAnnotations;

namespace CQRSpattern.Models
{
    public class AddUserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
