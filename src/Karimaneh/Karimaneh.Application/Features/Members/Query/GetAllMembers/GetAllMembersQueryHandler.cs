using AutoMapper;
using Common.Application.CQRS.Query;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Loans.Specifications;
using Karimaneh.Application.Features.Members.DTOs;
using Karimaneh.Application.Features.Members.Specifications;
using Karimaneh.Application.Features.Wallets.Specifications;
using Karimaneh.Domain.LoanAgg.Repository;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Domain.RequestAgg.Repository;
using Karimaneh.Domain.WalletAgg.Repository;

namespace Karimaneh.Application.Features.Members.Query.GetAllMembers
{
    public class GetAllMembersQueryHandler : IBaseQueryHandler<GetAllMembersQuery, IEnumerable<MemberResponseDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;


        public GetAllMembersQueryHandler(IMemberRepository memberRepository, ILoanRepository loanRepository, IRequestRepository requestRepository, IWalletRepository walletRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _loanRepository = loanRepository;
            _requestRepository = requestRepository;
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberResponseDto>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var spec = new MemberGetAllSpec();
            var members = await _memberRepository.GetAllAsync(spec, cancellationToken);
            var loans = await _loanRepository.GetAllAsync(new LoanGetAllSpec(), cancellationToken);

            return await Task.WhenAll(members.Select(async item =>
            {
                var wallet = await _walletRepository.GetByIdAsync(item.WalletId, new WalletGetAllSpec(), cancellationToken)
                 ?? throw new NotFoundException("Wallet Not Found!");

                var totalLoansReceived = loans.Where(x => x.MemberId == item.Id).Sum(x => x.Amount);
                var response = _mapper.Map<MemberResponseDto>(item);
                response.TotalRecivedLoanAmount = totalLoansReceived;
                response.DebtAmount = wallet.Balance;
                return response;
            }));
        }
    }
}
