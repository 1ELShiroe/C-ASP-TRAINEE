using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Decimal ValueTotal { get; set; }
        public ICollection<OrderProductModel>? OrderProduct { get; set; }
    }

}
