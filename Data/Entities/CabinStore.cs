using System;
using Data.Shared;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class CabinStore : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        // Association to ApplicationUser
        public required string StoreOwnerId { get; set; }
        public ApplicationUser? StoreOwner { get; set; }

        // Association to Products
        public ICollection<Product> Products { get; set; } = new List<Product>();
        // Navigation property for associated ProductCategories
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    }

}