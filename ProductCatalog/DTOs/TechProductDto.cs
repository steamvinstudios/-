namespace ProductCatalog.DTOs
{
    public class TechProductDto : ProductDto
    {
        public string Processor { get; set; }
        public int RAM { get; set; }
        public string Manufacturer { get; set; }
    }
}
