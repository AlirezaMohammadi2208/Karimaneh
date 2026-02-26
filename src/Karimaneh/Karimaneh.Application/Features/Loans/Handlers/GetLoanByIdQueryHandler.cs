using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Loans.DTOs;
using Karimaneh.Application.Features.Loans.Queries;
using Karimaneh.Application.Features.Loans.Specifications;
using Karimaneh.Domain.LoanAgg.Repository;

namespace Karimaneh.Application.Features.Loans.Handlers
{
    public class GetLoanByIdQueryHandler : IBaseQueryHandler<GetLoanByIdQuery, LoanResponseDto>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetLoanByIdQueryHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<LoanResponseDto> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new LoanGetAllSpec();
            var loan = await _loanRepository.GetByIdAsync(request.Id, spec, cancellationToken);
            return _mapper.Map<LoanResponseDto>(loan);
        }
    }
}
