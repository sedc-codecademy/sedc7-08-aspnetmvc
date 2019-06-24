using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sedc.MultipleModelView.WebApp.Models;

namespace Sedc.MultipleModelView.WebApp.Controllers
{
    public class PizzaController : Controller
    {
        private List<Pizza> Pizzas { get; set; }

        public PizzaController()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza
                {
                    Name = "Margarita",
                    Description = "Vegetarian",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient {Name = "tomato sauce"},
                        new Ingredient {Name = "double dose of mozzarella"},
                        new Ingredient {Name = "oregano"},
                    },
                    Price = 350.0
                },
                new Pizza
                {
                    Name = "Carbonara",
                    Description = "New",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient {Name = "fresh cream"},
                        new Ingredient {Name = "mozzarella"},
                        new Ingredient {Name = "bacon"},
                        new Ingredient {Name = "mushrooms"},
                        new Ingredient {Name = "parmesan"},
                    },
                    Price = 380.0
                },
                new Pizza
                {
                    Name = "Burger Classic",
                    Description = "New",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient {Name = "100% mozarella"},
                        new Ingredient {Name = "burger sauce"},
                        new Ingredient {Name = "pickles"},
                        new Ingredient {Name = "spicy beef"},
                        new Ingredient {Name = "cheddar cheese"},
                        new Ingredient {Name = "fresh tomato"},
                    },
                    Price = 390.0
                },
                new Pizza
                {
                    Name = "Barbecue Passion Chicken",
                    Description = "n/a",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient {Name = "mozarella"},
                        new Ingredient {Name = "barbecue sauce"},
                        new Ingredient {Name = "tender chicken breast"},
                        new Ingredient {Name = "onions"},
                        new Ingredient {Name = "fresh green peppers"},
                    },
                    Price = 400.0
                },
                new Pizza
                {
                    Name = "Italian Passion",
                    Description = "Vegetarian",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient {Name = "tomato sauce"},
                        new Ingredient {Name = "mozzarella"},
                        new Ingredient {Name = "pesto sauce"},
                        new Ingredient {Name = "parmesan"},
                        new Ingredient {Name = "fresh tomatoes"},
                        new Ingredient {Name = "basil"},
                    },
                    Price = 410.0
                }

            };
        }

        public IActionResult Index()
        {
            var menu = new MenuViewModel
            {
                Offers = new List<Offer>
                {
                    new Offer
                    {
                        Name = "Vegetarian Offer",
                        Description = "Margarita + Italian Passion",
                        Pizzas = Pizzas.Where(x=>x.Description == "Vegetarian").ToList(),
                        Price = 700.0
                    },
                    new Offer
                    {
                        Name = "Newcomers Offer",
                        Description = "Carbonara + Burger Classic",
                        Pizzas = Pizzas.Where(x=>x.Description == "New").ToList(),
                        Price = 700.0
                    }
                },
                Pizzas = Pizzas
            };

            return View(menu);
        }
    }
}