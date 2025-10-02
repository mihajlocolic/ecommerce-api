namespace ecommerce_api.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Name { get; set; } = null;
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; } = null;
        public int Stock { get; set; }


    }
}
