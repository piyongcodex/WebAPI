using CQRSpattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSpattern.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
