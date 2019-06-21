using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtoModels
{
    public class Pizza : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public int BasePrice { get; set; }

        public Pizza(string name, string description, int price)
        {
            Name = name;
            Description = description;
            PizzaIngredients = new List<PizzaIngredient>();
            BasePrice = price;
        }

        public Pizza()
        {
            PizzaIngredients = new List<PizzaIngredient>();
        }

        public int GetPrice(SizeEnum size)
        {
            switch (size)
            {
                case SizeEnum.Small:
                    return BasePrice;
                case SizeEnum.Medium:
                    return (int)Math.Ceiling(BasePrice * 1.2);
                case SizeEnum.Large:
                    return (int)Math.Ceiling(BasePrice * 1.4);
                default:
                    return (int)Math.Ceiling(BasePrice * 1.2);
            }
        }
    }
}
