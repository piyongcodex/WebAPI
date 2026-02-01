using CQRSpattern.Domain.Entities;

namespace CQRSpattern.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
        Task<User> Add(User user, CancellationToken cancellationToken);
        Task<User> Update(Guid id, string username, string name, string password, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<User> GetUser(Guid id, CancellationToken cancellationToken);
        Task<bool> Login(string username, string password, CancellationToken cancellationToken);
        Task<bool> Exist(string username, CancellationToken cancellationToken);
        Task<bool> Exist(Guid id, CancellationToken cancellationToken);
    }
}
