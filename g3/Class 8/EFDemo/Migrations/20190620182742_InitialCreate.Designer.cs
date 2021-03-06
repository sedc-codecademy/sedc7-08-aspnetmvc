﻿// <auto-generated />
using System;
using EFDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDemo.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20190620182742_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDemo.Models.BonusCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Points");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("BonusCards");
                });

            modelBuilder.Entity("EFDemo.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("EFDemo.Models.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CinemaId");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("EFDemo.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("EFDemo.Models.MovieHall", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("HallId");

                    b.HasKey("MovieId", "HallId");

                    b.HasIndex("HallId");

                    b.ToTable("MovieHalls");
                });

            modelBuilder.Entity("EFDemo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BonusCardId");

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.HasIndex("BonusCardId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EFDemo.Models.Hall", b =>
                {
                    b.HasOne("EFDemo.Models.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId");
                });

            modelBuilder.Entity("EFDemo.Models.MovieHall", b =>
                {
                    b.HasOne("EFDemo.Models.Hall", "Hall")
                        .WithMany("MovieHalls")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFDemo.Models.Movie", "Movie")
                        .WithMany("MovieHalls")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFDemo.Models.User", b =>
                {
                    b.HasOne("EFDemo.Models.BonusCard", "BonusCard")
                        .WithOne("User")
                        .HasForeignKey("EFDemo.Models.User", "BonusCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
