using System;
using AutoMapper;
using Core.DtoModels;
using Core.ViewrRequests;
using Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Helpers
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<ApplicationUser, UserProfileDto>();
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductInventory, ProductInventoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<UserAddress, UserAddressDto>();
            CreateMap<CreateProductCategoryModel, ProductCategory>();
            CreateMap<CreateProductModel, Product>();
            CreateMap<AddProductInventoryModel, ProductInventory>();
        }
    }
}