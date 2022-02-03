using Store.Shared.Dto;

namespace Store.Business.Services;
public interface IProductService
{
    Task<Guid> CreateAsync(ProductDto dto);
    Task<ProductDto> GetByIdAsync(Guid id);
    Task<List<ProductDto>> GetAllAsync(ProductRequest request);

}
