using System;
using Core.DtoModels;
using Core.ViewrRequests;

namespace Services.Interfaces
{
	public interface IProductCategoryService
	{
        Task<BaseDtoListResponse<ProductCategoryDto>> ListAsync();
        Task<BaseDtoResponse<ProductCategoryDto>> GetById(Guid id);
        Task<BaseDtoResponse<ProductCategoryDto>> Add(CreateProductCategoryModel request);
        Task<BaseDtoResponse<ProductCategoryDto>> Update(Guid id, CreateProductCategoryModel request);
        Task<BaseDtoResponse<ProductCategoryDto>> Delete(Guid id);
        //Task<BaseDtoListResponse<ProductCategoryDto>> GetItemsByCategory(Guid CategoryId);
    }
}