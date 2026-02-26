using Common.Application.CQRS.Command;
using Karimaneh.Application.Features.Funds.Specifications;
using Karimaneh.Domain.FundAgg.Repository;
using Karimaneh.Domain.LoanAgg;
using Karimaneh.Domain.LoanAgg.Repository;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Domain.RequestAgg.Repository;
using Karimaneh.Domain.TransactionAgg;
using Karimaneh.Domain.TransactionAgg.Repository;

namespace Karimaneh.Application.Features.Requests.Command.ConfirmRequest
{
    public class ConfirmRequestCommandHandler : IBaseCommandHandler<ConfirmRequestCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IFundRepository _fundRepository;
        private readonly IMemberRepository _memberRepository;

        public ConfirmRequestCommandHandler(ITransactionRepository transactionRepository, ILoanRepository loanRepository, IRequestRepository requestRepository, IFundRepository fundRepository, IMemberRepository memberRepository)
        {
            _transactionRepository = transactionRepository;
            _loanRepository = loanRepository;
            _requestRepository = requestRepository;
            _fundRepository = fundRepository;
            _memberRepository = memberRepository;
        }

        public async Task Handle(ConfirmRequestCommand request, CancellationToken cancellationToken)
        {
            var req = await _requestRepository.GetRequestById(request.RequestId);

            var loan = Loan.Create(
                 request.StartDate,
                 request.Amount,
                 request.InstallmentCount,
                 request.RequestId,
                 request.UserId,
                 req.MemberId);

            loan.CreateLoanInstallments(request.UserId);

            await _loanRepository.AddAsync(loan, cancellationToken);

            var fund = (await _fundRepository.GetAllAsync(new FundGetAllSpec(), cancellationToken)).First();

            var creditWalletId = (await _memberRepository.GetMemberById(req.MemberId)).WalletId;

            var transaction = Transaction.Create(fund.WalletId, creditWalletId, loan.Amount, "Loan Payment", TransactionType.LoanPayment, request.UserId);
            await _transactionRepository.AddAsync(transaction, cancellationToken);

            req.Confirm();

            await _requestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
