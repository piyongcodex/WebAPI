namespace CQRSpattern.Application.Users.Commands.CreateUser
{
    public class CreateUserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
