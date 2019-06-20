using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtoModels
{
    public class OrderItem : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public SizeEnum Size { get; set; }

        public OrderItem()
        {
            
        }
    }
}
