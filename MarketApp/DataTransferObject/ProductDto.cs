using System.ComponentModel.DataAnnotations;

namespace MarketApp.DataTransferObject
{
    public class ProductDto
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
