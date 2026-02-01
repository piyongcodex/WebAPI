namespace CQRSpattern.Application.Users.Queries
{
    public class GetUserQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
