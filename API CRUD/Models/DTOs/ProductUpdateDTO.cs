namespace api.Models.DTOs
{
    public class ProductUpdateDTO
    {
        public Guid Id { get; set; }
        public String? Name { get; set; }
        public Decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}