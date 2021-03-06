﻿// <auto-generated />
using Football.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Football.Migrations
{
    [DbContext(typeof(FootballDbContext))]
    [Migration("20190625191904_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Football.Models.Match", b =>
                {
                    b.Property<int>("HteamId");

                    b.Property<int>("AteamId");

                    b.Property<int>("Id");

                    b.Property<string>("Score");

                    b.HasKey("HteamId", "AteamId");

                    b.HasIndex("AteamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Football.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Football.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Football.Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("Football.Models.Match", b =>
                {
                    b.HasOne("Football.Models.Team", "Ateam")
                        .WithMany("Amatches")
                        .HasForeignKey("AteamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Football.Models.Team", "Hteam")
                        .WithMany("Hmatches")
                        .HasForeignKey("HteamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Football.Models.Player", b =>
                {
                    b.HasOne("Football.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Football.Models.Team", b =>
                {
                    b.HasOne("Football.Models.Trainer", "Trainer")
                        .WithOne("Team")
                        .HasForeignKey("Football.Models.Team", "TrainerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
