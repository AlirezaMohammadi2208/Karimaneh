using AutoMapper;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Karimaneh.Domain.LoanAgg.Events;
using MediatR;

namespace Karimaneh.Application.Features.Loans.EventHandlers
{
    public class LoanCreatedAuditHandler : INotificationHandler<LoanCreatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public LoanCreatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(LoanCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var auditLog = _mapper.Map<AuditLog>(domainEvent.Loan);
            auditLog.ActionType = AuditActionType.Create;
            auditLog.UserId = domainEvent.UserId;
            await _auditLogService.LogAsync(auditLog);
        }
    }
}
