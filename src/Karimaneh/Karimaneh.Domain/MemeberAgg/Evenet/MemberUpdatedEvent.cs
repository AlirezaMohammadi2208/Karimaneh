using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.MemeberAgg.Evenet
{
    public class MemberUpdatedEvent : INotification
    {
        public Member Member { get; }
        public string? OldValue { get; }
        public Guid UserId { get; }

        public MemberUpdatedEvent(Member member, Guid userId, string? oldValue)
        {
            Member = member;
            UserId = userId;
            OldValue = oldValue;
        }
    }
}
