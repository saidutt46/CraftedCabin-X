using System;
using AutoMapper;
using Core.DtoModels;
using Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Helpers
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<ApplicationUser, UserProfileDto>();
        }
    }
}

