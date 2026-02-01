using CQRSpattern.Application.Users.Commands.CreateUser.Enums;

namespace CQRSpattern.Application.Users.Commands.CreateUser
{
    public class CreateUserResponse
    {
        public CreateUserResponseDto user { get; set; }
        public ResponseStatus response { get; set; }
      
    }
}
