using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Models
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options)
            : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Trainer> Trainers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(x => x.Players)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);


            modelBuilder.Entity<Trainer>()
                .HasOne(x => x.Team)
                .WithOne(x => x.Trainer)
                .HasForeignKey<Team>(x => x.TrainerId);

            modelBuilder.Entity<Match>()
                .HasKey(x => new { x.HteamId, x.AteamId });


            modelBuilder.Entity<Match>()
                  .HasOne(x => x.Hteam)
                  .WithMany(x => x.Hmatches)
                  .HasForeignKey(x => x.HteamId)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(x => x.Ateam)
                .WithMany(x => x.Amatches)
                .HasForeignKey(x => x.AteamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trainer>().HasData(new Trainer
            {
                Id = 1,
                Name = "Sarry"
            }, new Trainer
            {
                Id = 2,
                Name = "Emery"
            });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                Id = 1,
                Name = "Chelsea",
                TrainerId = 1,
            }, new Team
            {
                Id = 2,
                Name = "Arsenal",
                TrainerId = 2,
            });

            modelBuilder.Entity<Player>().HasData(new Player("Keppa") { Id = 1, TeamId = 1 },
               new Player("Luiz") { Id = 2, TeamId = 1 },
               new Player("Hazard") { Id = 3, TeamId = 1 }, 
               new Player("Cheh") { Id = 4, TeamId = 2 },
               new Player("Mustafi") { Id = 5, TeamId = 2 },
               new Player("Aubamejang") { Id = 6, TeamId = 2 });


            

        }
    }
}
