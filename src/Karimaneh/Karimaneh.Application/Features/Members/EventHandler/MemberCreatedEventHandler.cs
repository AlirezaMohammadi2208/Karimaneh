using AutoMapper;
using Karimaneh.Application.Features.Members.DTOs;
using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Karimaneh.Domain.MemeberAgg.Evenet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Members.EventHandler
{
    public class MemberCreatedEventHandler : INotificationHandler<MemberCreatedEvent>
    {
        private readonly IAuditLogService _auditLogService;
        private readonly IMapper _mapper;

        public MemberCreatedEventHandler(IAuditLogService auditLogService, IMapper mapper)
        {
            _auditLogService = auditLogService;
            _mapper = mapper;
        }

        public async Task Handle(MemberCreatedEvent notification, CancellationToken cancellationToken)
        {
            var memberDto = _mapper.Map<MemberResponseDto>(notification.Member);
            var audit = _mapper.Map<AuditLog>(memberDto);
            audit.ActionType = AuditActionType.Create;
            audit.UserId = notification.UserId;
            await _auditLogService.LogAsync(audit, cancellationToken);
        }
    }
}
