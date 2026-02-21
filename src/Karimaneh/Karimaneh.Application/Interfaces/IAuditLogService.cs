using Karimaneh.Domain.Entities;

namespace Karimaneh.Application.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(AuditLog auditLog, CancellationToken cancellationToken = default);
    }
}
