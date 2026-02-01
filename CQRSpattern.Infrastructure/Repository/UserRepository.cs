using CQRSpattern.Domain.Abstractions;
using CQRSpattern.Domain.Entities;
using CQRSpattern.Infrastructure.Common.Interface;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CQRSpattern.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _db;
        private readonly IDbConnectionFactory _connectionFactory;
        public UserRepository(ApplicationDbContext db, IDbConnectionFactory connectionFactory)
        {
            _db = db;
            _connectionFactory = connectionFactory;
        }
        public async Task<User> Add(User user, CancellationToken cancellationToken)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancellationToken);
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
        public async Task<User?> GetUser(Guid id, CancellationToken cancellationToken)
        {
            using IDbConnection sqlConnection = _connectionFactory.CreateConnection();

            var command = new CommandDefinition(
                @"SELECT Id, Name, Username, Password
                FROM users
                WHERE Id = @UserId",
                new { UserId = id },
                cancellationToken: cancellationToken
            );

            return await sqlConnection.QueryFirstOrDefaultAsync<User>(command);
        }
        public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
        {
            using IDbConnection sqlConnection = _connectionFactory.CreateConnection();

            var command = new CommandDefinition(
               @"SELECT Id, Name, Username, Password
                FROM users",
               cancellationToken: cancellationToken);

            return await sqlConnection.QueryAsync<User>(command);
        }
        public async Task<bool> Login(string username, string password, CancellationToken cancellationToken)
        {
            return true;
        }
        public async Task<User> Update(Guid id, string name, string username, string password, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

            user.Name = name;
            user.Username = username;
            user.Password = password;

            await _db.SaveChangesAsync(cancellationToken);

            return user;

        }
        public async Task<bool> Exist(string username, CancellationToken cancellationToken)
        {
            var exist = await _db.Users.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
            if (exist == null)
                return false;
            return true;
        }
        public async Task<bool> Exist(Guid id, CancellationToken cancellationToken)
        {
            var exist = await _db.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (exist == null)
                return false;
            return true;
        }

    }
}
