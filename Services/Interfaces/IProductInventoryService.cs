using System;
using Core.DtoModels;
using Core.ViewrRequests;

namespace Services.Interfaces
{
	public interface IProductInventoryService
	{
        Task<BaseDtoListResponse<ProductInventoryDto>> ListAsync();
        Task<BaseDtoResponse<ProductInventoryDto>> GetById(Guid id);
        Task<BaseDtoResponse<ProductInventoryDto>> Add(AddProductInventoryModel request);
        Task<BaseDtoResponse<ProductInventoryDto>> Update(Guid id, AddProductInventoryModel request);
        Task<BaseDtoResponse<ProductInventoryDto>> Delete(Guid id);
    }
}

