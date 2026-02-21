using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.BaseModels
{
    public abstract class BaseEntity
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        public IReadOnlyCollection<BaseDomainEvent> DomainEvents => _domainEvents;
        public Guid Id { get; set; }
        public void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void RemoveDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

    }
}
