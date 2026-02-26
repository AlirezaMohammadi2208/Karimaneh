using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Funds.DTOs;
using Karimaneh.Application.Features.Funds.Queries;
using Karimaneh.Application.Features.Funds.Specifications;
using Karimaneh.Domain.FundAgg.Repository;

namespace Karimaneh.Application.Features.Funds.Handlers
{
    public class GetFundByIdQueryHandler : IBaseQueryHandler<GetFundByIdQuery, FundResponseDto>
    {
        private readonly IFundRepository _fundRepository;
        private readonly IMapper _mapper;

        public GetFundByIdQueryHandler(IFundRepository fundRepository, IMapper mapper)
        {
            _fundRepository = fundRepository;
            _mapper = mapper;
        }

        public async Task<FundResponseDto> Handle(GetFundByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new FundGetAllSpec();
            var fund = await _fundRepository.GetByIdAsync(request.Id, spec, cancellationToken);
            return _mapper.Map<FundResponseDto>(fund);
        }
    }
}
