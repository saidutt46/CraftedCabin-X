using System;
using Data.Context;
using Data.Entities;
using Repository.Interfaces;
using Repository.Shared;

namespace Repository.Implementation
{
	public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext options) : base(options)
        {
        }
    }
}

