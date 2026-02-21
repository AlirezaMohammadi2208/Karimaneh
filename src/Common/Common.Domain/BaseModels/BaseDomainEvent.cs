using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.BaseModels
{
    public abstract class BaseDomainEvent
    {
        protected BaseDomainEvent(DateTime creationDate)
        {
            CreationDate = creationDate;
        }

        public DateTime CreationDate { get; private set; }

    }
}
