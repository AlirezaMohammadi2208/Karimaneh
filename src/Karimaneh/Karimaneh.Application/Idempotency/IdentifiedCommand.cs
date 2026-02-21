using FluentValidation;
using Karimaneh.Application.Features.Transactions.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Karimaneh.Application.Idempotency
{
    public class IdentifiedCommand<T, R> : IRequest<R>
     where T : IRequest<R>
    {
        public T Command { get; }
        public Guid Id { get; }
        public IdentifiedCommand(T command, Guid id)
        {
            Command = command;
            Id = id;
        }
    }

    public class IdentifiedCommandValidator : AbstractValidator<IdentifiedCommand<CreateTransactionCommand, bool>>
    {
        public IdentifiedCommandValidator(ILogger<IdentifiedCommandValidator> logger)
        {
            RuleFor(command => command.Id).NotEmpty();

            if (logger.IsEnabled(LogLevel.Trace))
            {
                logger.LogTrace("INSTANCE CREATED - {ClassName}", GetType().Name);
            }
        }
    }
}
