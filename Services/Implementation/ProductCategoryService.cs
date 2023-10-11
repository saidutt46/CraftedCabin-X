using System;
using AutoMapper;
using Core.DtoModels;
using Core.ViewrRequests;
using Data.Entities;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(
            IProductCategoryRepository categoryRepository,
            IMapper mapper
            )
        {
            _productCategoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseDtoListResponse<ProductCategoryDto>> ListAsync()
        {
            try
            {
                IList<ProductCategory> categories = await _productCategoryRepository.ListAll();
                if (categories != null)
                {
                    IList<ProductCategoryDto> result = _mapper.Map<IList<ProductCategory>, IList<ProductCategoryDto>>(categories);
                    BaseDtoListResponse<ProductCategoryDto> response = new BaseDtoListResponse<ProductCategoryDto>(result);
                    return response;
                }
                else
                {
                    return new BaseDtoListResponse<ProductCategoryDto>("No Categories found, please try after adding new categories(s)");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoListResponse<ProductCategoryDto>(ex.Message);
            }
        }

        public async Task<BaseDtoResponse<ProductCategoryDto>> GetById(Guid id)
        {
            ProductCategory category = await _productCategoryRepository.GetById(id);

            if (category == null)
                return new BaseDtoResponse<ProductCategoryDto>("Category Not Found");
            ProductCategoryDto result = _mapper.Map<ProductCategory, ProductCategoryDto>(category);
            return new BaseDtoResponse<ProductCategoryDto>(result);
        }

        public async Task<BaseDtoResponse<ProductCategoryDto>> Add(CreateProductCategoryModel request)
        {
            try
            {
                ProductCategory model = _mapper.Map<CreateProductCategoryModel, ProductCategory>(request);
                ProductCategory category = await _productCategoryRepository.Add(model);
                if (category != null)
                {
                    ProductCategoryDto result = _mapper.Map<ProductCategory, ProductCategoryDto>(category);
                    return new BaseDtoResponse<ProductCategoryDto>(result);
                }
                else
                {
                    return new BaseDtoResponse<ProductCategoryDto>("Unable to create a new category, try again");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductCategoryDto>($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<ProductCategoryDto>> Update(Guid id, CreateProductCategoryModel request)
        {
            try
            {
                ProductCategory category = await _productCategoryRepository.GetById(id);
                if (category != null)
                {
                    category.Description = request.Description;
                    category.Name = request.Name;
                    await _productCategoryRepository.Update(category);
                    ProductCategory updatedResult = await _productCategoryRepository.GetById(id);
                    ProductCategoryDto result = _mapper.Map<ProductCategory, ProductCategoryDto>(updatedResult);
                    return new BaseDtoResponse<ProductCategoryDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<ProductCategoryDto>("Product Category Not found");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductCategoryDto>($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<ProductCategoryDto>> Delete(Guid id)
        {
            try
            {
                ProductCategory category = await _productCategoryRepository.GetById(id);
                if (category != null)
                {
                    await _productCategoryRepository.Delete(category);
                    ProductCategoryDto result = _mapper.Map<ProductCategory, ProductCategoryDto>(category);
                    return new BaseDtoResponse<ProductCategoryDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<ProductCategoryDto>("Unable to delete: Category Not found");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductCategoryDto>($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}

