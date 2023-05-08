namespace api.Models.DTOs
{
    public class CustomerDTO
    {
        public Guid? Id { get; set; }
        public String? Name { get; set; }
        public String? Password { get; set; }
        public String? Changepassword {get; set; }
    }
}