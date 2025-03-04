using ProductCatalog.DTOs;
using ProductCatalog.Models;
using ProductCatalog.Repositories.Interfaces;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return MapToDto(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(MapToDto);
        }

        private ProductDto MapToDto(Product product)
        {
            return product switch
            {
                FoodProduct p => new FoodProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ExpiryDate = p.ExpiryDate,
                    Calories = p.Calories
                },
                TechProduct p => new TechProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Processor = p.Processor,
                    RAM = p.RAM,
                    Manufacturer = p.Manufacturer
                },
                _ => throw new InvalidOperationException("Unknown product type")
            };
        }

        public Task CreateAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Остальные методы будут реализованы позже
        public async Task<IEnumerable<FoodProductDto>> GetAllFoodAsync()
        {
            var products = await _repository.GetAllFoodProductsAsync();
            return products.Select(p => (FoodProductDto)MapToDto(p));
        }

        public async Task<IEnumerable<TechProductDto>> GetAllTechAsync()
        {
            var products = await _repository.GetAllTechProductsAsync();
            return products.Select(p => (TechProductDto)MapToDto(p));
        }
    }
}
