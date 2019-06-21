using System;
using System.Collections.Generic;

namespace SEDC.PizzaHut.Domain.Models
{
    public class Order : Entity
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderName { get; set; }

        public string OrderAddress { get; set; }

        public string OrderCity { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual User User { get; set; }
    }
}