using AutoMapper;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Karimaneh.Domain.MemeberAgg.Evenet;
using MediatR;

namespace Karimaneh.Application.Features.Members.EventHandler
{
    public class MemberUpdatedAuditHandler : INotificationHandler<MemberUpdatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public MemberUpdatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(MemberUpdatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var auditLog = _mapper.Map<AuditLog>(domainEvent.Member);
            auditLog.ActionType = AuditActionType.Update;
            auditLog.UserId = domainEvent.UserId;
            auditLog.OldValue = domainEvent.OldValue;
            await _auditLogService.LogAsync(auditLog);
        }
    }
}
