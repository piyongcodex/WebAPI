namespace CQRSpattern.Application.Users.Commands.CreateUser
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
