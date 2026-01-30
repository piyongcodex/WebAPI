using System.ComponentModel.DataAnnotations;

namespace CQRSpattern.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
