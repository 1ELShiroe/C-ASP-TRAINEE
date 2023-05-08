using api.Models;
using api.Models.DTOs;

namespace api.Repository.interfaces
{
    public interface ICustomerRepository
    {
        Object Login(CustomerModel customer);
        Object Register(CustomerModel customer);
        String FindAndDelete(GetGuidDTO dto);
        List<CustomerInfoDTO> GetAll();
        CustomerInfoDTO GetCustomerById(Guid Id);
        String FindAndUpdate(CustomerDTO dto);
    }
}