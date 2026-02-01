namespace CCQRSpattern.Application.Common.Interfaces
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
