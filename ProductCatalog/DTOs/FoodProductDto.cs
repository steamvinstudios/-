namespace ProductCatalog.DTOs
{
    public class FoodProductDto : ProductDto
    {
        public DateTime ExpiryDate { get; set; }
        public int Calories { get; set; }
    }
}
