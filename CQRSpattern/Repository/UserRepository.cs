using CQRSpattern.Abstractions;
using CQRSpattern.Contracts;
using CQRSpattern.Data;
using CQRSpattern.Models;
using CQRSpattern.Models.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using System.Threading;

namespace CQRSpattern.Repository
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
            var findUser = await _db.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            if (findUser == null) return null;

            findUser.Name = user.Name;
            await _db.SaveChangesAsync(cancellationToken);

            return findUser;
        }
    }
}
