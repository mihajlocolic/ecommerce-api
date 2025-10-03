using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce_api.Models
{

    [Table("Categories")]
    public class Category
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Name { get; set; } = null;

        public List<Product> Products { get; } = new();
    }
}
