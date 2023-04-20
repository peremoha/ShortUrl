using Microsoft.EntityFrameworkCore;

namespace Inforce.Models
{
    public class ShortenerContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<ShortUrl> ShortUrls { get; set; } = null!;

        public ShortenerContext(DbContextOptions<ShortenerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortUrl>().HasIndex(u => u.FullUrl).IsUnique();
        }
    }

}
