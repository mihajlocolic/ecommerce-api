using System.ComponentModel.DataAnnotations;

namespace ecommerce_api.Models
{
    public class ProductDTO
    {
        public long Id { get; set; }

        [Required]
        public string? Name { get; set; } = null;
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public required string? Description { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
