using api.Infrastructure.Context;
using api.Repository.interfaces;
using api.Models;
using api.services;
using api.Models.DTOs;

namespace api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Object Login(CustomerModel customer)
        {
            var user = _context.Customers.Where(i =>
                i.Name!.ToLower() == customer.Name!.ToLower()
                && i.Password == customer.Password
            ).DefaultIfEmpty().Single();

            if (user != null)
            {
                return new
                {
                    error = false,
                    message = "request made successfully.",
                    customer = user,
                    token = TokenService.GenerateToken(user)
                };
            }

            return new
            {
                error = true,
                message = "user not found."
            };
        }
        public Object Register(CustomerModel customer)
        {
            List<CustomerModel> customers = _context.Customers.ToList();

            if (customers.Exists(x => x.Name == customer.Name))
            {
                return new ResponseModel()
                {
                    Error = true,
                    Message = "name is already in use."
                };
            }

            if (!(customer?.Password?.Length >= 8))
            {
                return new ResponseModel()
                {
                    Error = true,
                    Message = "the password provided has less than 8 characters."
                };
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return new ResponseModel()
            {
                Error = false,
                Name = customer.Name,
                Token = TokenService.GenerateToken(customer)
            };
        }
        public List<CustomerInfoDTO> GetAll()
        {
            List<CustomerModel> customers = _context.Customers.ToList();
            var newList = new List<CustomerInfoDTO>();

            customers.ForEach(item =>
                newList.Add(new CustomerInfoDTO
                {
                    Id = item?.Id,
                    Name = item?.Name,
                    Role = item?.Role
                })
            );
            return newList;
        }
        public CustomerInfoDTO GetCustomerById(Guid Id)
        {
            var customer = _context.Customers.Find(Id);
            return new CustomerInfoDTO
            {
                Id = customer?.Id,
                Name = customer?.Name,
                Role = customer?.Role
            };
        }
        public String FindAndDelete(GetGuidDTO dto)
        {
            var customer = _context.Customers.Where(i => i.Id == dto.Id)
                    .DefaultIfEmpty().Single();

            if (customer == null)
            {
                return "No user found with given ID.";
            }

            _context.Customers.Remove(customer!);
            _context.SaveChanges();

            return "user deleted successfully.";
        }
        public String FindAndUpdate(CustomerDTO dto)
        {
            var validCustomer = _context.Customers.Where(
                i => i.Name!.ToLower() == dto.Name!.ToLower() && dto.Password == i.Password
            )
                 .DefaultIfEmpty()
                 .Single();

            if (dto.Changepassword!.Length < 8)
            {
                return "Password entered with less than 8 characters.";
            }

            if (dto.Password == dto.Changepassword)
            {
                return "the new password entered is the same as the old one.";
            }

            if (validCustomer != null)
            {
                var newCustomer = new CustomerModel()
                {
                    Id = validCustomer.Id,
                    Name = validCustomer.Name,
                    Password = dto.Changepassword,
                };

                _context.Entry(validCustomer).CurrentValues.SetValues(newCustomer);
                _context.SaveChanges();
                return "password changed successfully.";
            }
            return "No user found with given name.";
        }
    }
}