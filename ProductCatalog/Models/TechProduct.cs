namespace ProductCatalog.Models
{
    public class TechProduct : Product
    {
        public string Processor { get; set; }
        public int RAM { get; set; } // в ГБ
        public string Manufacturer { get; set; }
    }

}
