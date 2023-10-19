using System;
using Core.DtoModels;
using Core.ViewrRequests;

namespace Services.Interfaces
{
	public interface ICabinStoreService
	{
        Task<BaseDtoListResponse<CabinStoreDto>> ListAsync();
        Task<BaseDtoResponse<CabinStoreDto>> GetById(Guid id);
        Task<BaseDtoResponse<CabinStoreDto>> Add(CreateStoreModel request);
        Task<BaseDtoResponse<CabinStoreDto>> Update(Guid id, CreateStoreModel request);
        Task<BaseDtoResponse<CabinStoreDto>> Delete(Guid id);
        Task<BaseDtoListResponse<ProductDto>>  GetProductsByStoreId(Guid storeId);
        Task<BaseDtoListResponse<ProductCategoryDto>> GetCategoriesByStoreId(Guid storeId);
    }
}

