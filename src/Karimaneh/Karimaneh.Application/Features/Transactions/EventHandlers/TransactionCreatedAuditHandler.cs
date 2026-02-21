using AutoMapper;
using Karimaneh.Application.Features.Transactions.DTOs;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;

namespace Karimaneh.Application.Features.Transactions.EventHandlers
{
    public class TransactionCreatedAuditHandler : INotificationHandler<TransactionCreatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public TransactionCreatedAuditHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(TransactionCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var transactionDto = _mapper.Map<TransactionResponseDto>(domainEvent.Transaction);

            var auditLog = _mapper.Map<AuditLog>(transactionDto);
            auditLog.ActionType = AuditActionType.Create;
            auditLog.UserId = domainEvent.UserId;

            await _auditLogService.LogAsync(auditLog);
        }
    }
}
