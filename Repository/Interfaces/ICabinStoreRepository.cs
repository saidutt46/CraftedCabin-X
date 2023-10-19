using System;
using Data.Entities;
using Data.Shared;

namespace Repository.Interfaces
{
	public interface ICabinStoreRepository : IRepository<CabinStore>
	{
        Task<IList<Product>> GetProductsByStoreId(Guid storeId);
        Task<IList<ProductCategory>> GetCategoriesByStoreId(Guid storeId);
    }
}

