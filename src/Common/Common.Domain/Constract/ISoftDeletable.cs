using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Constract
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
