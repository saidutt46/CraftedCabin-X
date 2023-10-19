using System;
using AutoMapper;
using Core.DtoModels;
using Core.ViewrRequests;
using Data.Entities;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementation
{
	public class CabinStoreService : ICabinStoreService
	{
        private readonly ICabinStoreRepository _cabinStoreRepository;
        private readonly IMapper _mapper;

        public CabinStoreService(
            ICabinStoreRepository cabinStoreRepository,
            IMapper mapper
            )
        {
            _cabinStoreRepository = cabinStoreRepository;
            _mapper = mapper;
        }

        public async Task<BaseDtoListResponse<CabinStoreDto>> ListAsync()
        {
            try
            {
                IList<CabinStore> stores = await _cabinStoreRepository.ListAll();
                if (stores != null)
                {
                    IList<CabinStoreDto> result = _mapper.Map<IList<CabinStore>, IList<CabinStoreDto>>(stores);
                    BaseDtoListResponse<CabinStoreDto> response = new BaseDtoListResponse<CabinStoreDto>(result);
                    return response;
                }
                else
                {
                    return new BaseDtoListResponse<CabinStoreDto>("No Stores found, please try after adding new stores(s)");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoListResponse<CabinStoreDto>(ex.Message);
            }
        }

        public async Task<BaseDtoListResponse<ProductDto>> GetProductsByStoreId(Guid storeId)
        {
            try
            {
                IList<Product> products = await _cabinStoreRepository.GetProductsByStoreId(storeId);
                if (products != null)
                {
                    IList<ProductDto> result = _mapper.Map<IList<Product>, IList<ProductDto>>(products);
                    BaseDtoListResponse<ProductDto> response = new BaseDtoListResponse<ProductDto>(result);
                    return response;
                }
                else
                {
                    return new BaseDtoListResponse<ProductDto>("No products found, please try after adding new products or refresh(s)");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoListResponse<ProductDto>(ex.Message);
            }
        }

        public async Task<BaseDtoListResponse<ProductCategoryDto>> GetCategoriesByStoreId(Guid storeId)
        {
            try
            {
                IList<ProductCategory> categories = await _cabinStoreRepository.GetCategoriesByStoreId(storeId);
                if (categories != null)
                {
                    IList<ProductCategoryDto> result = _mapper.Map<IList<ProductCategory>, IList<ProductCategoryDto>>(categories);
                    BaseDtoListResponse<ProductCategoryDto> response = new BaseDtoListResponse<ProductCategoryDto>(result);
                    return response;
                }
                else
                {
                    return new BaseDtoListResponse<ProductCategoryDto>("No Stores found, please try after adding new stores(s)");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoListResponse<ProductCategoryDto>(ex.Message);
            }
        }

        public async Task<BaseDtoResponse<CabinStoreDto>> GetById(Guid id)
        {
            CabinStore store = await _cabinStoreRepository.GetById(id);

            if (store == null)
                return new BaseDtoResponse<CabinStoreDto>("Store Not Found");
            CabinStoreDto result = _mapper.Map<CabinStore, CabinStoreDto>(store);
            return new BaseDtoResponse<CabinStoreDto>(result);
        }

        public async Task<BaseDtoResponse<CabinStoreDto>> Add(CreateStoreModel request)
        {
            try
            {
                CabinStore model = _mapper.Map<CreateStoreModel, CabinStore>(request);
                CabinStore store = await _cabinStoreRepository.Add(model);
                if (store != null)
                {
                    CabinStoreDto result = _mapper.Map<CabinStore, CabinStoreDto>(store);
                    return new BaseDtoResponse<CabinStoreDto>(result);
                }
                else
                {
                    return new BaseDtoResponse<CabinStoreDto>("Unable to create a new store, try again");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<CabinStoreDto>($"An error occurred when saving the store: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<CabinStoreDto>> Update(Guid id, CreateStoreModel request)
        {
            try
            {
                CabinStore store = await _cabinStoreRepository.GetById(id);
                if (store != null)
                {
                    store.Name = request.Name;
                    store.Description = request.Description;
                    await _cabinStoreRepository.Update(store);
                    CabinStore updatedResult = await _cabinStoreRepository.GetById(id);
                    CabinStoreDto result = _mapper.Map<CabinStore, CabinStoreDto>(updatedResult);
                    return new BaseDtoResponse<CabinStoreDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<CabinStoreDto>("Store Not found");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<CabinStoreDto>($"An error occurred when updating the store: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<CabinStoreDto>> Delete(Guid id)
        {
            try
            {
                CabinStore store = await _cabinStoreRepository.GetById(id);
                if (store != null)
                {
                    await _cabinStoreRepository.Delete(store);
                    CabinStoreDto result = _mapper.Map<CabinStore, CabinStoreDto>(store);
                    return new BaseDtoResponse<CabinStoreDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<CabinStoreDto>("Unable to delete: Store Not found");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<CabinStoreDto>($"An error occurred when deleting the store: {ex.Message}");
            }
        }
    }
}

