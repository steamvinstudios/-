namespace ProductCatalog.Models
{
    public class FoodProduct : Product
    {
        public DateTime ExpiryDate { get; set; }
        public int Calories { get; set; }
    }

}
