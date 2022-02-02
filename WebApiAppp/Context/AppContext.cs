using Microsoft.EntityFrameworkCore;
using WebApiAppp.Models;

namespace WebApiAppp.Context
{
    public class AppContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User{Id = 1,Name = "tom",Age = 22},
                new User{Id = 2,Name = "alice",Age = 22}
            );
            base.OnModelCreating(modelBuilder);
            
        }
    }
}