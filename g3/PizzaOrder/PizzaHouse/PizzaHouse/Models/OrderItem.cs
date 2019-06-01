namespace PizzaHouse.Models
{
    public class OrderItem
    {
        public Pizza Pizza { get; set; }
        public SizeEnum Size { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Pizza pizza, SizeEnum size, int quantity)
        {
            Pizza = pizza;
            Size = size;
            Quantity = quantity;
        }
    }
}
