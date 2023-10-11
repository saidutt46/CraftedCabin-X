using System;
using Core.DtoModels;
using Core.ViewrRequests;

namespace Services.Interfaces
{
	public interface IProductService
	{
        Task<BaseDtoListResponse<ProductDto>> ListAsync();
        Task<BaseDtoResponse<ProductDto>> GetById(Guid id);
        Task<BaseDtoResponse<ProductDto>> Add(CreateProductModel request);
        Task<BaseDtoResponse<ProductDto>> Update(Guid id, CreateProductModel request);
        Task<BaseDtoResponse<ProductDto>> Delete(Guid id);
	}
}