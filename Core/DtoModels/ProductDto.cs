using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DtoModels
{
	public class ProductDto
	{
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string SKU { get; set; }
        public decimal Price { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}

