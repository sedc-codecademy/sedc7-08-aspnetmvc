using Microsoft.EntityFrameworkCore;

namespace EFDemo.Models
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BonusCard> BonusCards { get; set; }
        public DbSet<MovieHall> MovieHalls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieHall>().HasKey(x => new {x.MovieId, x.HallId});
            modelBuilder.Entity<MovieHall>()
                .HasOne<Movie>(x => x.Movie)
                .WithMany(x => x.MovieHalls)
                .HasForeignKey(x => x.MovieId);
            modelBuilder.Entity<MovieHall>()
                .HasOne<Hall>(x => x.Hall)
                .WithMany(x => x.MovieHalls)
                .HasForeignKey(x => x.HallId);

            modelBuilder.Entity<Hall>()
                .HasOne(x => x.Cinema)
                .WithMany(x => x.Halls);

            modelBuilder.Entity<User>()
                .HasOne(x => x.BonusCard)
                .WithOne(x => x.User)
                .HasForeignKey<BonusCard>(x => x.UserId);

            modelBuilder.Entity<BonusCard>()
                .HasOne(x => x.User)
                .WithOne(x => x.BonusCard)
                .HasForeignKey<User>(x => x.BonusCardId);
        }
    }
}
