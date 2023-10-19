using System;
using Data.Context;
using Data.Entities;
using Repository.Interfaces;
using Repository.Shared;
using static Repository.Helpers.CustomSpecifications;

namespace Repository.Implementation
{
	public class CabinStoreRepository : EfRepository<CabinStore>, ICabinStoreRepository
	{
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CabinStoreRepository(ApplicationDbContext options, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository) : base(options)
		{
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
		}

        public async Task<IList<Product>> GetProductsByStoreId(Guid storeId)
        {
            var spec = new ProductsByStoreSpecification(storeId);
            return await _productRepository.List(spec);
        }

        public async Task<IList<ProductCategory>> GetCategoriesByStoreId(Guid storeId)
        {
            var spec = new CategoriesByStoreSpecification(storeId);
            return await  _productCategoryRepository.List(spec);
        }
    }
}

