using System;
using Data.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public required string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public required string SKU { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Guid ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }

        // Navigation property for the associated ProductInventory
        public required ProductInventory ProductInventory { get; set; }
    }
}

