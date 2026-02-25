using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.MemeberAgg.Evenet
{
    public record MemberCreatedEvent : INotification 
    {
        public MemberCreatedEvent(Guid userId, Member member)
        {
            UserId = userId;
            Member = member;
        }

        public Guid UserId { get;private set; }
        public Member Member { get;private set; }
    }
}
