using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Constract
{
    public interface IUnitOfWork 
    {
        Task<bool> SaveChnageAsync();
    }
}
