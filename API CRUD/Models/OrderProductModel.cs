using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class OrderProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; }
        public Int32 Quantity { get; set; }
        public Decimal Amount { get; set; }
        public Guid OrderId { get; set; }
        public OrderModel? Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductModel? Product { get; set; }
    }
}