using System;
using Data.Helpers;

namespace Data.Shared
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<IList<T>> ListAll();
        Task<T> GetSingleBySpec(ISpecification<T> spec);
        Task<IList<T>> List(ISpecification<T> spec);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}

