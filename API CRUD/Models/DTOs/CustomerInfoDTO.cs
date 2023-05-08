namespace api.Models.DTOs
{
    public class CustomerInfoDTO
    {
        public required Guid? Id { get; set; }
        public required String? Name { get; set; }
        public required String? Role { get; set; }
    }
}