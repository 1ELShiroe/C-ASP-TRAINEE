namespace api.Models.DTOs
{
    public class OrderProductDTO
    {
        public Guid Id { get; set; }
        public required Guid CustomerId { get; set; }
        public required List<Guid> ProductId { get; set; }
    }
}