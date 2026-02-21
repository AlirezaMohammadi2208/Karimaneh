using AutoMapper;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Transactions.Commands;
using Microsoft.Extensions.Logging;

namespace Karimaneh.Application.Features.Transactions.Handlers
{
    public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, bool>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletAccountRepository _walletAccountRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IWalletAccountRepository walletAccountRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _walletAccountRepository = walletAccountRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            if (request.DebitWalletAccountId == request.CreditWalletAccountId)
                throw new ConflictException("The parties to the transaction are the same.");

            var spec = new WalletAccountGetAllSpec();
            var from = await _walletAccountRepository.GetByIdAsync(request.DebitWalletAccountId, spec, cancellationToken)
                ?? throw new NotFoundException("Debit Account Not Found!");
            var to = await _walletAccountRepository.GetByIdAsync(request.CreditWalletAccountId, spec, cancellationToken)
                ?? throw new NotFoundException("Credit Account Not Found!");

            from.Debit(request.Amount);
            to.Credit(request.Amount);

            var transaction = Transaction.Create(
                request.DebitWalletAccountId,
                request.CreditWalletAccountId,
                request.Amount,
                request.Description,
                request.Type,
                request.UserId);

            await _transactionRepository.AddAsync(transaction, cancellationToken);

            //if (request.InstallmentId is not null)
            //{
            //    var installment = await _unitOfWork.Installments.GetByIdAsync(request.InstallmentId.Value, new InstallmentGetAllSpec(), cancellationToken);
            //    if (installment == null)
            //        throw new NotFoundException("Installment Not Found!");

            //    installment.Payment(transaction.Id);
            //}

            //return _mapper.Map<TransactionResponseDto>(transaction);
            return true;
        }
    }

    // Use for Idempotency in Command process
    public class CreateTransactionIdentifiedCommandHandler : IdentifiedCommandHandler<CreateTransactionCommand, bool>
    {
        public CreateTransactionIdentifiedCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<CreateTransactionCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true; // Ignore duplicate requests for processing transaction.
        }
    }
}
