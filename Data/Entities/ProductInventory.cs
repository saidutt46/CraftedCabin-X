using System;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Shared;

namespace Data.Entities
{
    [Table("product_inventory")]
    public class ProductInventory : BaseEntity
    {
        public required int Quantity { get; set; }

        // Navigation property for the associated Product
        public required Product Product { get; set; }

        // Foreign key property for the associated Product
        public Guid ProductId { get; set; }
    }
}

