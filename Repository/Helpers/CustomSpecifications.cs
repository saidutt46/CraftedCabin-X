using System;
using Data.Entities;
using Data.Helpers;

namespace Repository.Helpers
{
	public class CustomSpecifications
	{
        public class ProductsByStoreSpecification : BaseSpecification<Product>
        {
            public ProductsByStoreSpecification(Guid storeId)
                : base(product => product.CabinStoreId == storeId)
            {
                AddInclude(product => product.ProductCategory);
            }
        }

        public class CategoriesByStoreSpecification : BaseSpecification<ProductCategory>
        {
            public CategoriesByStoreSpecification(Guid storeId)
                : base(category => category.CabinStoreId == storeId)
            {
                AddInclude(category => category.Products);
            }
        }

    }
}

