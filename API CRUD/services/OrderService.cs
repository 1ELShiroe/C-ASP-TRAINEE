using api.Models;
using api.Models.DTOs;
using api.Repository.interfaces;
using api.services.interfaces;

namespace api.services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        private readonly ICustomerRepository _customerRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IOrderProductRepository orderProductRepository,
            ICustomerRepository customerRepository
            )
        {
            _orderProductRepository = orderProductRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public async Task InsertNewOrder(OrderProductDTO dto)
        {
            decimal valueTotal = _productRepository.GetAmmountSum(dto.ProductId);

            OrderModel order = new OrderModel()
            {
                Id = Guid.NewGuid(),
                ClientId = dto.CustomerId,
                ValueTotal = valueTotal
            };

            await _orderRepository.InsertOrder(order);

            var dups = dto.ProductId.GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .Select(x => new { Id = x.Key, Count = x.Count() })
                        .ToList();


            dups.ForEach(item =>
           {

               if (item.Count > 1)
               {
                   var product = _productRepository.FindById(new GetGuidDTO()
                   {
                       Id = item.Id
                   });
                   var amount = _productRepository.GetProductAmmount(item.Id) * item.Count;

                   dto.ProductId.RemoveAll(x => x == item.Id);

                   var orderProduct = new OrderProductModel
                   {
                       OrderId = order.Id,
                       ProductId = item.Id,
                       Amount = amount,
                       Quantity = item.Count
                   };

                   _orderProductRepository.InsertOrderProduct(orderProduct);
               }

           });
            foreach (var productId in dto.ProductId)
            {
                var amount = _productRepository.GetProductAmmount(productId);

                var orderProduct = new OrderProductModel
                {
                    OrderId = order.Id,
                    ProductId = productId,
                    Amount = amount,
                    Quantity = 1
                };

                await _orderProductRepository.InsertOrderProduct(orderProduct);
            }
        }
        public OrderDTO GetOrderById(Guid Id)
        {
            List<OrderProductModel> listOrderProduct = _orderProductRepository.GetOrders(Id);
            var products = new List<ProductDTO>();

            decimal ammout = 0;
            listOrderProduct.ForEach(item =>
            {
                ProductDTO product = _productRepository.GetProductById(item.ProductId);
                product.Value = item.Amount;
                product.Quantity = item.Quantity;
                ammout += item.Amount;
                products.Add(product);
            });

            var order = _orderRepository.GetById(Id);
            var customer = _customerRepository.GetCustomerById(order.ClientId);

            return new OrderDTO()
            {
                Id = order.Id,
                products = products,
                customer = customer,
                Amount = ammout
            };
        }
        public String FindAndUpdateOrder(OrderProductDTO dto)
        {
            _orderProductRepository.FindAndRemove(dto.Id);
            var dups = dto.ProductId.GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .Select(x => new { Id = x.Key, Count = x.Count() })
                        .ToList();


            dups.ForEach(item =>
           {

               if (item.Count > 1)
               {
                   var product = _productRepository.FindById(new GetGuidDTO()
                   {
                       Id = item.Id
                   });
                   var amount = _productRepository.GetProductAmmount(item.Id) * item.Count;

                   dto.ProductId.RemoveAll(x => x == item.Id);

                   var orderProduct = new OrderProductModel
                   {
                       OrderId = dto.Id,
                       ProductId = item.Id,
                       Amount = amount,
                       Quantity = item.Count
                   };

                   _orderProductRepository.InsertOrderProduct(orderProduct);
               }

           });
            foreach (var productId in dto.ProductId)
            {
                var amount = _productRepository.GetProductAmmount(productId);

                var orderProduct = new OrderProductModel
                {
                    OrderId = dto.Id,
                    ProductId = productId,
                    Amount = amount,
                    Quantity = 1
                };

                _orderProductRepository.InsertOrderProduct(orderProduct);
            }
            return "";
        }
    }
}
