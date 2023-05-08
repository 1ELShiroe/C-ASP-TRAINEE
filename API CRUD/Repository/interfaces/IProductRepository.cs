using api.Models.DTOs;

namespace api.Repository.interfaces
{
    public interface IProductRepository
    {
        List<ProductUpdateDTO> GetAll();
        ProductDTO GetProductById(Guid Id);
        Object Create(ProductDTO product);
        Decimal GetAmmountSum(List<Guid> ids);
        Decimal GetProductAmmount(Guid id);
        String FindAndUpdate(ProductUpdateDTO dto);
        String FindAndDelete(Guid Id);
        ProductUpdateDTO FindById(GetGuidDTO dto);
    }
}