namespace CQRSpattern.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? Username { get; }
        bool IsAuthenticated { get; }
        bool IsInRole(string role);
        IEnumerable<string> Roles { get; }
    }
}
