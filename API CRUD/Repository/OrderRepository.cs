using api.Infrastructure.Context;
using api.Repository.interfaces;
using api.Models;
using api.Models.DTOs;

namespace api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _context;
        private readonly IOrderProductRepository _dbOrder;
        private readonly IProductRepository _dbProduct;
        public OrderRepository(ApplicationContext context, IOrderProductRepository dbOrder, IProductRepository dbProduct)
        {
            _context = context;
            _dbOrder = dbOrder;
            _dbProduct = dbProduct;
        }

        public async Task<OrderModel> InsertOrder(OrderModel order)
        {
            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return new OrderModel();
        }
        public OrderModel GetById(Guid Id)
        {
            return _context.Orders.Find(Id) ?? new OrderModel();
        }
        public List<OrderModel> GetByIdAll()
        {
            List<OrderModel> orderList = _context.Orders.ToList();

            return orderList;
        }
        public String DisableById(GetGuidDTO dto)
        {
            // var order = _context.Orders.Find(dto.Id);
            // order!.isDisable = true;

            // _context.Orders.Update(order);

            return "";
        }
        public String FindAndDelete(GetGuidDTO dto)
        {
            var validProduct = _context.Orders.Where(i => i.Id == dto.Id)
                    .DefaultIfEmpty()
                    .Single();

            if (validProduct == null)
            {
                return "no order found with the given ID.";
            }

            _context.Orders.Remove(validProduct);
            _context.SaveChanges();

            return "order deleted successfully.";
        }
    }
}