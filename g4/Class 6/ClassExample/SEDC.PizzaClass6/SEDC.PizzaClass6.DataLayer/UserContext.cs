using Microsoft.EntityFrameworkCore;
using SEDC.PizzaClass6.DomainModels.Models;

namespace SEDC.PizzaClass6.DataLayer
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
