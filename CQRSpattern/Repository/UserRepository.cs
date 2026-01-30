using CQRSpattern.Contracts;
using CQRSpattern.Data;
using CQRSpattern.Models;
using CQRSpattern.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CQRSpattern.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User> Add(User user, CancellationToken cancellationToken)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }
        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (user == null) return false;

            _db.Users.Remove(user);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
        public async Task<User> GetUser(Guid id, CancellationToken cancellationToken)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
        {
            return await _db.Users.ToListAsync(cancellationToken);
        }
        public async Task<bool> Login(string username, string password, CancellationToken cancellationToken)
        {
            return true;
        }
        public async Task<User> Update(UpdateUserDTO user, Guid id, CancellationToken cancellationToken)
        {
            var findUser = _db.Users.FirstOrDefault(u => u.Id == id);
            if (findUser == null) return null;

            findUser.Name = user.Name;
            await _db.SaveChangesAsync();

            return findUser;
        }
    }
}
