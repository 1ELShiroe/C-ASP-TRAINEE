using api.Models.DTOs;
using api.Repository.interfaces;
using api.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRespository;

        public OrderController(IOrderService orderService, IOrderRepository orderRespository)
        {
            _orderService = orderService;
            _orderRespository = orderRespository;
        }
        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] OrderProductDTO dto)
        {
            await _orderService.InsertNewOrder(dto);
            return Ok();
        }
        [HttpPost("all")]
        [Authorize]
        public IActionResult GetOrderAll()
        {
            var list = _orderRespository.GetByIdAll();
            var response = new List<OrderDTO>();
            list.ForEach(item =>
                response.Add(_orderService.GetOrderById(item.Id))
            );

            return Ok(
            new
            {
                orders = response,
                Legth = response.Count
            }
            );
        }
        [HttpPost("byId")]
        [Authorize]
        public IActionResult FindById([FromBody] GetGuidDTO dto)
        {
            var order = _orderService.GetOrderById(dto.Id);
            if (order.products.Count == 0)
            {
                return NotFound(new { message = "No order found with given id." });
            }
            return Ok(new { order });
        }
        [HttpDelete()]
        [Authorize]
        public IActionResult Delete([FromBody] GetGuidDTO dto)
        {
            var response = _orderRespository.FindAndDelete(dto);
            return Ok(
                new
                {
                    message = response
                });
        }
        [HttpPut()]
        [Authorize]
        public IActionResult Put([FromBody] OrderProductDTO dto)
        {
            _orderService.FindAndUpdateOrder(dto);

            return Ok();
        }
    }
}