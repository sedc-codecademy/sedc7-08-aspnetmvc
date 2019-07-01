using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Domain
{
    public class Pizza
    {

        public Pizza(int id, string name, string description, int price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PizzaSize Size { get; set; }

        private int Price { get; set; }

        public int GetPrice(PizzaSize size)
        {
            switch (size)
            {
                case PizzaSize.Small:
                    return Price;
                case PizzaSize.Medium:
                    return (int)Math.Ceiling(Price * 1.2);
                case PizzaSize.Large:
                    return (int)Math.Ceiling(Price * 1.4);
                default:
                    return (int)Math.Ceiling(Price * 1.2);
            }
        }


    }
}
