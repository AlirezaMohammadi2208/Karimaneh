using Common.Application.CQRS.Command;

namespace Karimaneh.Application.Features.Transactions.Commands
{
    public class SetConfirmTransactionComand : IBaseCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
