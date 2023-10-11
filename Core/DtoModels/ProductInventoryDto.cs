using System;
using Data.Entities;

namespace Core.DtoModels
{
	public class ProductInventoryDto
	{
        public required string Id { get; set; }
        public required int Quantity { get; set; }

        // Foreign key property for the associated Product
        public Guid ProductId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Deleted { get; set; }
    }
}

