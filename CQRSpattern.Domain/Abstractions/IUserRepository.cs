using CQRSpattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSpattern.Domain.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
        Task<User> Add(User user, CancellationToken cancellationToken);
        //Task<User> Update(UpdateUserDTO user, Guid id, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Task<User> GetUser(Guid id, CancellationToken cancellationToken);
        Task<bool> Login(string username, string password, CancellationToken cancellationToken);
        Task<User> Exist(string username, CancellationToken cancellationToken);
    }
}
