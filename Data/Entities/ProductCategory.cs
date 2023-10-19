using System;
using Data.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("product_category")]
    public class ProductCategory : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        // Navigation property for associated Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
        // Optional: if you want to associate categories with a store
        public Guid? CabinStoreId { get; set; }
        public CabinStore? CabinStore { get; set; }
    }
}