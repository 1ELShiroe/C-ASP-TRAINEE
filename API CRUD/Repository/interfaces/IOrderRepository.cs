using api.Models;
using api.Models.DTOs;

namespace api.Repository.interfaces
{
    public interface IOrderRepository
    {
        Task<OrderModel> InsertOrder(OrderModel order);
        List<OrderModel> GetByIdAll();
        OrderModel GetById(Guid Id);
        String DisableById(GetGuidDTO dto);
        String FindAndDelete(GetGuidDTO dto);
    }
}