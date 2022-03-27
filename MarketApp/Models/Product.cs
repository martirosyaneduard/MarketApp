using System.ComponentModel.DataAnnotations;

namespace MarketApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
