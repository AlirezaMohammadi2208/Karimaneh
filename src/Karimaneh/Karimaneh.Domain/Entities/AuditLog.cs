using Common.Domain.BaseModels;

namespace Karimaneh.Domain.Entities
{
    public class AuditLog : BaseEntity
    {
        public string EntityName { get; set; }
        public Guid? EntityId { get; set; }
        public AuditActionType ActionType { get; set; }
        public Guid UserId { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
    public enum AuditActionType
    {
        Create,
        Update,
        Delete,
        Login,
        Logout
    }
}
