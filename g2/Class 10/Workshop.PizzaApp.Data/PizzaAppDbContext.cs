using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Model;

namespace Workshop.PizzaApp.Data
{
    public class PizzaAppDbContext : DbContext
    {
        public DbSet<PizzaModel> Pizzas { get; set; }

        public DbSet<SizeModel> Sizes { get; set; }

        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<PizzaSizeModel> PizzaSizes { get; set; }

        public DbSet<PizzaOrderModel> PizzaOrders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-CO6AHNV\SQLEXPRESS; initial catalog=Pizza_App_DB;Integrated Security=True;");

            //data source=palmira##; initial catalog=PizzaAppDB;persisted Security info=True;user id=sa;password=Password1
        }
    }
}
