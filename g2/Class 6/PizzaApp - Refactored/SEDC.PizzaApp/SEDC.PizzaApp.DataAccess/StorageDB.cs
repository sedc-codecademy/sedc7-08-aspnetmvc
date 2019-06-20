using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.DataAccess
{
    public static class StorageDB
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza
            {
                Id = 1,
                Name = "Capri",
                Description = "The best pizza in town!",
                Size = PizzaSize.Medium,
                Price = 250
            },
            new Pizza
            {
                Id = 2,
                Name = "Pepperoni",
                Description = "The best pepperoni pizza in town!",
                Size = PizzaSize.Large,
                Price = 340
            },
            new Pizza
            {
                Id = 3,
                Name = "Napolitana",
                Description = "The best napolitana pizza in town!",
                Size = PizzaSize.Small,
                Price = 180
            }

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
                    new Pizza
                    {
                        Id = 1,
                        Name = "Capri",
                        Description = "The best pizza in town!",
                        Size = PizzaSize.Medium,
                        Price = 250
                    },
                    new Pizza
                    {
                        Id = 2,
                        Name = "Pepperoni",
                        Description = "The best pepperoni pizza in town!",
                        Size = PizzaSize.Large,
                        Price = 340
                    },
                }
            }
        };
    }
}
