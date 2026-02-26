using AutoMapper;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Karimaneh.Domain.LoanAgg.Events;
using MediatR;

namespace Karimaneh.Application.Features.Loans.EventHandlers
{
    public class InstallmentCreatedAuditHandler : INotificationHandler<InstallmentCreatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public InstallmentCreatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(InstallmentCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var auditLog = _mapper.Map<AuditLog>(domainEvent.Installment);
            auditLog.ActionType = AuditActionType.Create;
            auditLog.UserId = domainEvent.UserId;
            await _auditLogService.LogAsync(auditLog);
        }
    }
}
