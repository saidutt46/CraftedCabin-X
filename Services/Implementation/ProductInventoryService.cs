using System;
using AutoMapper;
using Core.DtoModels;
using Core.ViewrRequests;
using Data.Entities;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementation
{
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly IProductInventoryRepository _productInventoryRepository;
        private readonly IMapper _mapper;

        public ProductInventoryService(
            IProductInventoryRepository productInventoryRepository,
            IMapper mapper
            )
        {
            _productInventoryRepository = productInventoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseDtoListResponse<ProductInventoryDto>> ListAsync()
        {
            try
            {
                IList<ProductInventory> inventory = await _productInventoryRepository.ListAll();
                if (inventory != null)
                {
                    IList<ProductInventoryDto> result = _mapper.Map<IList<ProductInventory>, IList<ProductInventoryDto>>(inventory);
                    BaseDtoListResponse<ProductInventoryDto> response = new BaseDtoListResponse<ProductInventoryDto>(result);
                    return response;
                }
                else
                {
                    return new BaseDtoListResponse<ProductInventoryDto>("No Inventory found, please try after adding new inventory");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoListResponse<ProductInventoryDto>(ex.Message);
            }
        }

        public async Task<BaseDtoResponse<ProductInventoryDto>> GetById(Guid id)
        {
            ProductInventory inventory = await _productInventoryRepository.GetById(id);

            if (inventory == null)
                return new BaseDtoResponse<ProductInventoryDto>("No Inventory Found");
            ProductInventoryDto result = _mapper.Map<ProductInventory, ProductInventoryDto>(inventory);
            return new BaseDtoResponse<ProductInventoryDto>(result);
        }

        public async Task<BaseDtoResponse<ProductInventoryDto>> Add(AddProductInventoryModel request)
        {
            try
            {
                ProductInventory model = _mapper.Map<AddProductInventoryModel, ProductInventory>(request);
                ProductInventory inventory = await _productInventoryRepository.Add(model);
                if (inventory != null)
                {
                    ProductInventoryDto result = _mapper.Map<ProductInventory, ProductInventoryDto>(inventory);
                    return new BaseDtoResponse<ProductInventoryDto>(result);
                }
                else
                {
                    return new BaseDtoResponse<ProductInventoryDto>("Unable to create new inventory, try again");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductInventoryDto>($"An error occurred when saving the inventory: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<ProductInventoryDto>> Update(Guid id, AddProductInventoryModel request)
        {
            try
            {
                ProductInventory inventory = await _productInventoryRepository.GetById(id);
                if (inventory != null)
                {
                    inventory.Quantity = request.Quantity;
                    await _productInventoryRepository.Update(inventory);
                    ProductInventory updatedResult = await _productInventoryRepository.GetById(id);
                    ProductInventoryDto result = _mapper.Map<ProductInventory, ProductInventoryDto>(updatedResult);
                    return new BaseDtoResponse<ProductInventoryDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<ProductInventoryDto>("No Inventory found to update, try again!");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductInventoryDto>($"An error occurred when updating the inventory: {ex.Message}");
            }
        }

        public async Task<BaseDtoResponse<ProductInventoryDto>> Delete(Guid id)
        {
            try
            {
                ProductInventory inventory = await _productInventoryRepository.GetById(id);
                if (inventory != null)
                {
                    await _productInventoryRepository.Delete(inventory);
                    ProductInventoryDto result = _mapper.Map<ProductInventory, ProductInventoryDto>(inventory);
                    return new BaseDtoResponse<ProductInventoryDto>(result);

                }
                else
                {
                    return new BaseDtoResponse<ProductInventoryDto>("Unable to delete: Inventory Not found");
                }
            }
            catch (Exception ex)
            {
                return new BaseDtoResponse<ProductInventoryDto>($"An error occurred when deleting the inventory: {ex.Message}");
            }
        }
    }
}

