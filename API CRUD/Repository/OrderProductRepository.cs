using api.Infrastructure.Context;
using api.Models;
using api.Models.DTOs;
using api.Repository.interfaces;

namespace api.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly ApplicationContext _context;
        public OrderProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<OrderProductModel> InsertOrderProduct(OrderProductModel product)
        {
            _context.OrderProduct.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
        public List<OrderProductModel> GetOrders(Guid Id)
        {
            List<OrderProductModel> orderProduct = _context.OrderProduct
                                .Where(p => p.OrderId == Id)
                                .ToList();

            return orderProduct;
        }

        public void FindAndRemove(Guid Id)
        {
            List<OrderProductModel> orderProduct = _context.OrderProduct
                                .Where(p => p.OrderId == Id)
                                .ToList();

            _context.OrderProduct.RemoveRange(orderProduct);
            _context.SaveChanges();
        }
    }
}