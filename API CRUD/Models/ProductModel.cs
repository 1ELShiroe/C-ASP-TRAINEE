using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public String? Name { get; set; }
        public Decimal Value { get; set; }
        public int Quantity { get; set; }
        public ICollection<OrderProductModel>? ProductOrder { get; set; }
    }
}