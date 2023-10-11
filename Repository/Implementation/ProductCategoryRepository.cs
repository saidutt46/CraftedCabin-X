using System;
using Data.Context;
using Data.Entities;
using Repository.Interfaces;
using Repository.Shared;

namespace Repository.Implementation
{
	public class ProductCategoryRepository : EfRepository<ProductCategory>, IProductCategoryRepository
	{
		public ProductCategoryRepository(ApplicationDbContext options) : base(options)
		{
		}
	}
}