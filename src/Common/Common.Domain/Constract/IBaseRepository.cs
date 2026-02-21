using Common.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Constract
{
    public interface IBaseRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
