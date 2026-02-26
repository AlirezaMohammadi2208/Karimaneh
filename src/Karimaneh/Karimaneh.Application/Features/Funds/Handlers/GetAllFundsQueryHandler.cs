using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Funds.DTOs;
using Karimaneh.Application.Features.Funds.Queries;
using Karimaneh.Application.Features.Funds.Specifications;
using Karimaneh.Domain.FundAgg.Repository;

namespace Karimaneh.Application.Features.Funds.Handlers
{
    public class GetAllFundsQueryHandler : IBaseQueryHandler<GetAllFundsQuery, IEnumerable<FundResponseDto>>
    {
        private readonly IFundRepository _fundRepository;
        private readonly IMapper _mapper;

        public GetAllFundsQueryHandler(IFundRepository fundRepository, IMapper mapper)
        {
            _fundRepository = fundRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FundResponseDto>> Handle(GetAllFundsQuery request, CancellationToken cancellationToken)
        {
            var spec = new FundGetAllSpec();
            var funds = await _fundRepository.GetAllAsync(spec, cancellationToken);
            return _mapper.Map<IEnumerable<FundResponseDto>>(funds);

        }
    }
}
