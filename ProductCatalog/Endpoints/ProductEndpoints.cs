using ProductCatalog.DTOs;
using ProductCatalog.Services;
using ProductCatalog.Services.Interfaces;

namespace ProductCatalog.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/products")
                .WithTags("Products");

            // Получение всех товаров
            group.MapGet("/", async (IProductService service)
                => Results.Ok(await service.GetAllAsync()))
                .WithName("GetAllProducts")
                .WithOpenApi();

            // Получение товара по ID
            group.MapGet("/{id}", async (int id, IProductService service) =>
            {
                var product = await service.GetByIdAsync(id);
                return product is null ? Results.NotFound() : Results.Ok(product);
            })
             .WithName("GetProductById")
             .WithOpenApi();

            // Создание нового товара
            group.MapPost("/", async (ProductDto dto, IProductService service) =>
            {
                await service.CreateAsync(dto);
                return Results.Created($"/api/products/{dto.Id}", dto);
            })
            .WithName("CreateProduct")
            .WithOpenApi();

            // Обновление товара
            group.MapPut("/{id}", async (int id, ProductDto dto, IProductService service) =>
            {
                if (id != dto.Id) return Results.BadRequest();
                await service.UpdateAsync(id, dto);
                return Results.NoContent();
            })
             .WithName("UpdateProduct")
             .WithOpenApi();

            // Удаление товара
            group.MapDelete("/{id}", async (int id, IProductService service) =>
            {
                await service.DeleteAsync(id);
                return Results.NoContent();
            })
            .WithName("DeleteProduct")
            .WithOpenApi();
            // Получение всех продуктов питания
            group.MapGet("/food", async (IProductService service) =>
            {
                var foodService = service as ProductService; // Пример реализации
                var result = await foodService.GetAllFoodAsync();
                return Results.Ok(result);
            })
            .WithName("GetAllFoodProducts")
            .WithOpenApi();

            // Получение всей техники
            group.MapGet("/tech", async (IProductService service) =>
            {
                var techService = service as ProductService;
                var result = await techService.GetAllTechAsync();
                return Results.Ok(result);
            })
            .WithName("GetAllTechProducts")
            .WithOpenApi();

        }

    }
}
