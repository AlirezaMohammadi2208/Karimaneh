//using Common.Application.CQRS.Command;
//using Karimaneh.Application.Features.Funds.Specifications;
//using Karimaneh.Domain.FundAgg.Repository;
//using Karimaneh.Domain.LoanAgg;
//using Karimaneh.Domain.LoanAgg.Repository;
//using Karimaneh.Domain.RequestAgg.Repository;
//using Karimaneh.Domain.TransactionAgg;
//using Karimaneh.Domain.TransactionAgg.Repository;

//namespace Karimaneh.Application.Features.Requests.Command.ConfirmRequest
//{
//    public class ConfirmRequestCommandHandler : IBaseCommandHandler<ConfirmRequestCommand>
//    {
//        private readonly ITransactionRepository _transactionRepository;
//        private readonly ILoanRepository _loanRepository;
//        private readonly IRequestRepository _requestRepository;
//        private readonly IFundRepository _fundRepository;

//        public ConfirmRequestCommandHandler(ITransactionRepository transactionRepository, ILoanRepository loanRepository, IRequestRepository requestRepository, IFundRepository fundRepository)
//        {
//            _transactionRepository = transactionRepository;
//            _loanRepository = loanRepository;
//            _requestRepository = requestRepository;
//            _fundRepository = fundRepository;
//        }

//        public async Task Handle(ConfirmRequestCommand request, CancellationToken cancellationToken)
//        {
//            var req = await _requestRepository.GetByIdAsync(request.RequestId, new RequestGetAllSpec(), cancellationToken);

//            var loan = Loan.Create(
//                 request.StartDate,
//                 request.Amount,
//                 request.InstallmentCount,
//                 request.RequestId,
//                 request.UserId);

//            loan.CreateLoanInstallments(request.UserId);

//            await _loanRepository.AddAsync(loan, cancellationToken);

//            var fund = (await _fundRepository.GetAllAsync(new FundGetAllSpec(), cancellationToken)).First();

//            var transaction = Transaction.Create(fund.WalletId, req.Member.WalletAccountId, loan.Amount, "Loan Payment", TransactionType.LoanPayment, request.UserId);
//            await _transactionRepository.AddAsync(transaction, cancellationToken);

//            req.Confirm();

//            await _requestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
//        }
//    }
//}
