using System;
using System.Collections.Generic;
using System.Text;

namespace Sedc.G2.PizzApp.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public bool ToBeDelivered { get; set; }

        public int UserId { get; set; }
    }
}
