namespace api.Models
{
    public class ResponseModel
    {
        public bool Error { get; set; }
        public String? Message { get; set; }
        public CustomerModel? Customer { get; set; }
        public List<CustomerModel>? Customers { get; set; }
        public String? Token { get; set; }
        public String? Name { get; set; }
    }
}