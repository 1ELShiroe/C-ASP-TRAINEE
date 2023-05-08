using api.Models;
using api.Models.DTOs;

namespace api.Repository.interfaces
{
    public interface IOrderProductRepository
    {
        Task<OrderProductModel> InsertOrderProduct(OrderProductModel product);
        List<OrderProductModel> GetOrders(Guid Id);
        void FindAndRemove(Guid Id);
    }
}