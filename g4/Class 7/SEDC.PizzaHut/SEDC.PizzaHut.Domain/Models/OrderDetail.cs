namespace SEDC.PizzaHut.Domain.Models
{
    public class OrderDetail : Entity
    {
        public int OrderID { get; set; }

        public int PizzaID { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public decimal Discount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}