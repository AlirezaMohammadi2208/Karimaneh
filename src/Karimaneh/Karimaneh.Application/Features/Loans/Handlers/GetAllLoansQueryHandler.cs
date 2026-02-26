using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Loans.DTOs;
using Karimaneh.Application.Features.Loans.Queries;
using Karimaneh.Application.Features.Loans.Specifications;
using Karimaneh.Domain.LoanAgg.Repository;

namespace Karimaneh.Application.Features.Loans.Handlers
{
    public class GetAllLoansQueryHandler : IBaseQueryHandler<GetAllLoansQuery, IEnumerable<LoanResponseDto>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetAllLoansQueryHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanResponseDto>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var spec = new LoanGetAllSpec();
            var loans = await _loanRepository.GetAllAsync(spec, cancellationToken);
            return _mapper.Map<IEnumerable<LoanResponseDto>>(loans);

        }
    }
}
