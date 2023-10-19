using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewrRequests
{
	public class CreateProductModel
	{
        [Required(ErrorMessage = "Product Name is required")]
        [MaxLength(255)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description Name is required")]
        [MaxLength(500)]
        public required string Description { get; set; }

        [Required(ErrorMessage = "SKU is required")]
        [MaxLength(50)]
        public required string SKU { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Guid ProductCategoryId { get; set; }
        public Guid CabinStoreId { get; set; }

    }
}

