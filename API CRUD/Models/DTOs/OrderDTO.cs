namespace api.Models.DTOs
{
    public class OrderDTO
    {
        public required Guid Id { get; set; }
        public required CustomerInfoDTO? customer { get; set; }
        public required List<ProductDTO> products { get; set; }
        public required Decimal Amount { get; set; }
    }
}