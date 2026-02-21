using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Constract
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IEnumerable<T?>> GetAllAsync();
        Task<T?> GetById(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
