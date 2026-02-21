using Karimaneh.Application.Interfaces;
using Karimaneh.Domain.Entities;
using Karimaneh.Infrastructure.Persistence;

namespace Karimaneh.Infrastructure.Audit
{
    public class AuditLogService : IAuditLogService
    {
        private readonly KarimanehDbContext _context;

        public AuditLogService(KarimanehDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(AuditLog auditLog, CancellationToken cancellationToken = default)
        {
            await _context.AuditLogs.AddAsync(auditLog, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
