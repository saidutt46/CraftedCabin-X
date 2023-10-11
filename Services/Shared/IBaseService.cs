using System;
using Core.DtoModels;

namespace Services.Shared
{
    public interface IBaseService<T>
    {
        Task<BaseDtoListResponse<T>> ListAsync();
        Task<BaseDtoResponse<T>> GetById(Guid id);
        Task<BaseDtoResponse<T>> Add(T entity);
        Task<BaseDtoResponse<T>> Update(Guid id, T entity);
        Task<BaseDtoResponse<T>> Delete(Guid id);
    }
}