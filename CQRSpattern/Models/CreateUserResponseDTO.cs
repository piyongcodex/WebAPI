using CQRSpattern.Models.Entities;

namespace CQRSpattern.Models
{
    public class CreateUserResponseDTO
    {
        public ResponseEnum response { get; set; }
        public User? user {  get; set; }
    }
    public enum ResponseEnum
    {
        Success,
        Conflict,
    }
}
