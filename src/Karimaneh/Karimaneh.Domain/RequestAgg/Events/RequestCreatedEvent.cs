using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.RequestAgg.Events
{
    public record RequestCreatedEvent : INotification   
    {
        public RequestCreatedEvent(Request request, Guid userId)
        {
            Request = request;
            UserId = userId;
        }

        public Request Request { get; private set; }
        public Guid UserId { get; private set; }
    }
}
