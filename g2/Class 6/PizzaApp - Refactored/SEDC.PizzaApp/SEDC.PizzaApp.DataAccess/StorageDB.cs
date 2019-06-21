using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.DataAccess
{
    public static class StorageDB
    {
        public static int PizzaId = 3;
        public static int OrderId = 1;
        public static int UserId = 2;

        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza(1, "Capri", "The best capri pizza in town!", 160),
            new Pizza(2, "Pepperoni", "The best pepperoni pizza in town!", 180),
            new Pizza(3, "Napolitana", "The best napolitana pizza in town!", 140)
    };

        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Martin",
                LastName = "Panovski",
                Address = "Test address br.24",
                Email = "panovski.martin93@gmail.com",
                Phone = "070/222-333",
                Password = "Netikazhuvam123"
            },
            new User
            {
                Id = 2,
                FirstName = "Dejan",
                LastName = "Jovanov",
                Address = "Test address br.26",
                Email = "d.jovanov92@gmail.com",
                Phone = "070/111-333",
                Password = "Netikazhuvam12345"
            }
        };
        
        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                User = new User
                {
                    Id = 1,
                    FirstName = "Martin",
                    LastName = "Panovski",
                    Address = "Test address br.24",
                    Email = "panovski.martin93@gmail.com",
                    Phone = "070/222-333",
                    Password = "Netikazhuvam123"
                },
                Pizzas = new List<Pizza>
                {
                    new Pizza(1, "Capri", "The best capri pizza in town!", 160),
                    new Pizza(2, "Pepperoni", "The best pepperoni pizza in town!", 180)
                }
            }
        };
    }
}
