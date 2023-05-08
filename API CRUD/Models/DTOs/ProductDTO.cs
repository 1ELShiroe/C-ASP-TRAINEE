namespace api.Models.DTOs
{
    public class ProductDTO
    {
        public Guid? Id { get; set; }
        public String? Name { get; set; }
        public Decimal Value { get; set; }
        public Int32? Quantity { get; set; }
    }
}