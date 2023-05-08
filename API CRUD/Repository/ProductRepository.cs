using api.Infrastructure.Context;
using api.Repository.interfaces;
using api.Models;
using api.Models.DTOs;

namespace api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<ProductUpdateDTO> GetAll()
        {
            var list = new List<ProductUpdateDTO>();
            var products = _context.Products.ToList();
            products.ForEach(item =>
            {
                list.Add(new ProductUpdateDTO()
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Value = item.Value,
                    Name = item.Name
                });
            });

            return list;
        }
        public ProductDTO GetProductById(Guid Id)
        {
            var product = _context.Products.Find(Id);
            return new ProductDTO()
            {
                Id = product!.Id,
                Name = product!.Name,
            };
        }
        public Decimal GetAmmountSum(List<Guid> ids)
        {
            return _context.Products
                .Where(p => ids.Contains(p.Id))
                .Sum(p => p.Quantity);
        }
        public Decimal GetProductAmmount(Guid id)
        {
            return _context.Products.Find(id)!.Value;
        }
        public Object Create(ProductDTO product)
        {
            var procutNew = new ProductModel()
            {
                Name = product.Name,
                Value = product.Value,
            };

            var response = _context.Products.Add(procutNew);
            _context.SaveChanges();

            return new ResponseModel()
            {
                Error = false,
                Message = "product successfully registered."
            };
        }
        public String FindAndUpdate(ProductUpdateDTO dto)
        {
            var validProduct = _context.Products.Where(i => i.Id == dto.Id)
                 .DefaultIfEmpty()
                 .Single();

            if (validProduct == null)
            {
                return "no product found with the given ID.";
            }

            var product = new ProductModel()
            {
                Id = validProduct.Id,
                Quantity = dto.Quantity,
                Name = dto.Name,
                Value = dto.Value
            };

            _context.Entry(validProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();

            return "product updated successfully.";
        }
        public String FindAndDelete(Guid Id)
        {
            var validProduct = _context.Products.Where(i => i.Id == Id)
                    .DefaultIfEmpty()
                    .Single();

            if (validProduct == null)
            {
                return "no product found with the given ID.";
            }

            _context.Products.Remove(validProduct);
            _context.SaveChanges();

            return "product deleted successfully.";
        }
        public ProductUpdateDTO FindById(GetGuidDTO dto)
        {
            var product = _context.Products.Where(i => i.Id == dto.Id)
                    .DefaultIfEmpty()
                    .Single();

            if (product == null)
            {
                return new ProductUpdateDTO { };
                // return "no product found with the given ID.";
            }

            return new ProductUpdateDTO()
            {
                Id = product.Id,
                Name = product.Name!,
                Value = product.Value,
                Quantity = product.Quantity
            };
        }
    }
}