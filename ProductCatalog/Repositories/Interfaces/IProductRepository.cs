using ProductCatalog.Models;

namespace ProductCatalog.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);

        // Специфичные методы для разных типов
        Task<IEnumerable<FoodProduct>> GetAllFoodProductsAsync();
        Task<IEnumerable<TechProduct>> GetAllTechProductsAsync();
    }
}
