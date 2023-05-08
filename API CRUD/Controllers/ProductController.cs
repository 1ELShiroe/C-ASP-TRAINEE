using api.Models;
using api.Models.DTOs;
using api.Repository.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost()]
        [Authorize]
        public IActionResult Create([FromBody] ProductDTO product)
        {
            var response = _productRepository.Create(product);
            return Ok(new
            {
                message = "product created successfully",
                product = response
            });
        }
        [HttpPost("byId")]
        [Authorize]
        public IActionResult FindById([FromBody] GetGuidDTO dto)
        {
            var response = _productRepository.FindById(dto);
            return Ok(response);
        }
        [HttpPost("all")]
        [Authorize]
        public IActionResult GetAll()
        {
            List<ProductUpdateDTO> response = _productRepository.GetAll();
            return Ok(new
            {
                products = response,
                length = response.Count
            });
        }
        [HttpPut()]
        [Authorize]
        public IActionResult Update([FromBody] ProductUpdateDTO dto)
        {
            var response = _productRepository.FindAndUpdate(dto);
            return Ok(
                new
                {
                    message = response
                });
        }
        [HttpDelete()]
        [Authorize]
        public IActionResult Delete([FromBody] GetGuidDTO dto)
        {
            var response = _productRepository.FindAndDelete(dto.Id);
            return Ok(
                new
                {
                    message = response
                });
        }
    }
}