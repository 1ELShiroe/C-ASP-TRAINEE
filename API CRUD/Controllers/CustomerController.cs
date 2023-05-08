using Microsoft.AspNetCore.Mvc;
using api.Repository.interfaces;
using api.Models;
using api.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers;

[ApiController]
[Route("customer")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository context)
    {
        _customerRepository = context;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] CustomerModel customer)
    {
        ResponseModel customerDb = (ResponseModel)_customerRepository.Register(customer);

        return customerDb.Error ? BadRequest
        (new
        {
            error = customerDb.Error,
            message = customerDb.Message
        }) :
        Ok(customerDb);
    }
    [HttpPost("login")]
    public ActionResult Login([FromBody] CustomerModel customer)
    {
        var customerDb = _customerRepository.Login(customer);

        return Ok(customerDb);
    }
    [HttpPost("all")]
    [Authorize]
    public IActionResult GetAll()
    {
        var customers = _customerRepository.GetAll();
        return Ok(new
        {
            customers,
            length = customers.Count
        });
    }
    [HttpDelete()]
    [Authorize]
    public IActionResult Delete([FromBody] GetGuidDTO dto)
    {
        return NoContent();
    }
    [HttpPut()]
    [Authorize]
    public IActionResult Put([FromBody] CustomerDTO dto)
    {
        var customer = _customerRepository.FindAndUpdate(dto);
        return Ok(customer);
    }
}