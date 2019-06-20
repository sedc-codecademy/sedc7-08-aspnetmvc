namespace DtoModels
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
        public SizeEnum Size { get; set; }
    }
}
