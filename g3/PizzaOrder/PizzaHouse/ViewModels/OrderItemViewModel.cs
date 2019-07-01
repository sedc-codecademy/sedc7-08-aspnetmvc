namespace ViewModels
{
    public class OrderItemViewModel
    {
        public PizzaViewModel Pizza { get; set; }
        public SizeEnum Size { get; set; }
        public int Quantity { get; set; }
    }
    
}
