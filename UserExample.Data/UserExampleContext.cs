using Microsoft.EntityFrameworkCore;
using UserExample.Model;

namespace UserExample.Data
{
    public class UserExampleContext : DbContext
    {
        public UserExampleContext(DbContextOptions<UserExampleContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().OwnsOne(u => u.Name);
            modelBuilder.Entity<User>().OwnsOne(u => u.ContactInformation);
            modelBuilder.Entity<User>().OwnsOne(u => u.Address);
        }
    }
}
