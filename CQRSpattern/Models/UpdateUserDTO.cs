using System.ComponentModel.DataAnnotations;

namespace CQRSpattern.Models
{
    public class UpdateUserDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
