using System;
using Data.Context;
using Data.Entities;
using Repository.Interfaces;
using Repository.Shared;

namespace Repository.Implementation
{
	public class ProductInventoryRepository : EfRepository<ProductInventory>, IProductInventoryRepository
    {
        public ProductInventoryRepository(ApplicationDbContext options) : base(options)
        {
        }
    }
}

