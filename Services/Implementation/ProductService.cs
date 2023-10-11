using System;
using AutoMapper;
using Core.DtoModels;
using Core.ViewrRequests;
using Data.Entities;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BaseDtoListResponse<ProductDto>> ListAsync()
        {
            try
            {
                IList<Product> categories = await _productRepository.ListAll();
                if (categories != null)
                {
                    IList<ProductDto> result = _mapper.Map<IList<Product>, IList<ProductDto>>(categories);
                    BaseDtoListResponse<ProductDto> response = new BaseDtoListResponse<ProductDto>(result);
                    return response;
                }
                else
                {
                    return new BaseDtoListResponse<ProductDto>("No Products found, please try after adding new product(s)");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoListResponse<ProductDto>(ex.Message);
            }
        }

        public async Task<BaseDtoResponse<ProductDto>> GetById(Guid id)
        {
            Product product = await _productRepository.GetById(id);

            if (product == null)
                return new BaseDtoResponse<ProductDto>("product Not Found");
            ProductDto result = _mapper.Map<Product, ProductDto>(product);
            return new BaseDtoResponse<ProductDto>(result);
        }

        public async Task<BaseDtoResponse<ProductDto>> Add(CreateProductModel request)
        {
            try
            {
                Product model = _mapper.Map<CreateProductModel, Product>(request);
                Product product = await _productRepository.Add(model);
                if (product != null)
                {
                    ProductDto result = _mapper.Map<Product, ProductDto>(product);
                    return new BaseDtoResponse<ProductDto>(result);
                }
                else
                {
                    return new BaseDtoResponse<ProductDto>("Unable to create a new product, try again");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductDto>($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<ProductDto>> Update(Guid id, CreateProductModel request)
        {
            try
            {
                Product product = await _productRepository.GetById(id);
                if (product != null)
                {
                    product.Description = request.Description;
                    product.Name = request.Name;
                    await _productRepository.Update(product);
                    Product updatedResult = await _productRepository.GetById(id);
                    ProductDto result = _mapper.Map<Product, ProductDto>(updatedResult);
                    return new BaseDtoResponse<ProductDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<ProductDto>("Product Not found");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductDto>($"An error occurred when updating the product: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<ProductDto>> Delete(Guid id)
        {
            try
            {
                Product product = await _productRepository.GetById(id);
                if (product != null)
                {
                    await _productRepository.Delete(product);
                    ProductDto result = _mapper.Map<Product, ProductDto>(product);
                    return new BaseDtoResponse<ProductDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<ProductDto>("Unable to delete: Product Not found");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductDto>($"An error occurred when deleting the product: {ex.Message}");
            }
        }
    }
}

