using api.Models.DTOs;

namespace api.services.interfaces
{
    public interface IOrderService
    {
        Task InsertNewOrder(OrderProductDTO dto);
        OrderDTO GetOrderById(Guid Id);
        String FindAndUpdateOrder(OrderProductDTO dto);
    }
}