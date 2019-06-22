﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.EntityFrameworkPizza.DataAccess;

namespace SEDC.EntityFrameworkPizza.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20190622092135_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.EntityFrameworkPizza.DataAccess.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, Address = "Bobsky Street", Name = "Bob Bobsky", Phone = "0800-3435-3444" },
                        new { Id = 2, Address = "Jill Street", Name = "Jill Wayne", Phone = "0800-3422-5455" }
                    );
                });

            modelBuilder.Entity("SEDC.EntityFrameworkPizza.DataAccess.Domain.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("OrderId");

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new { Id = 1, Name = "Kapri", OrderId = 1, Size = 1 },
                        new { Id = 2, Name = "Peperoni", OrderId = 1, Size = 0 },
                        new { Id = 3, Name = "Kapri", OrderId = 2, Size = 2 },
                        new { Id = 4, Name = "Margarita", OrderId = 2, Size = 0 }
                    );
                });

            modelBuilder.Entity("SEDC.EntityFrameworkPizza.DataAccess.Domain.Pizza", b =>
                {
                    b.HasOne("SEDC.EntityFrameworkPizza.DataAccess.Domain.Order", "Order")
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
