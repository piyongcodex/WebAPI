using CQRSpattern.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSpattern.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options){}
        public DbSet<User> Users { get; set; }
    }
}
