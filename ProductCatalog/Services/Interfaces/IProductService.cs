using ProductCatalog.DTOs;

namespace ProductCatalog.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task CreateAsync(ProductDto productDto);
        Task UpdateAsync(int id, ProductDto productDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<FoodProductDto>> GetAllFoodAsync();
        Task<IEnumerable<TechProductDto>> GetAllTechAsync();
    }
}
