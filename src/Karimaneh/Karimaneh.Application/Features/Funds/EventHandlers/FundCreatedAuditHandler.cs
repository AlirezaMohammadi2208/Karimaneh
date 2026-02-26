using AutoMapper;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Karimaneh.Domain.FundAgg.Events;
using MediatR;

namespace Karimaneh.Application.Features.Funds.EventHandlers
{
    public class FundCreatedAuditHandler : INotificationHandler<FundCreatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public FundCreatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(FundCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var auditLog = _mapper.Map<AuditLog>(domainEvent.Fund);
            auditLog.ActionType = AuditActionType.Create;
            auditLog.UserId = domainEvent.UserId;
            await _auditLogService.LogAsync(auditLog);
        }
    }
}
