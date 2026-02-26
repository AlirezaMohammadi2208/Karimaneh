using AutoMapper;
using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Wallets.DTOs;
using Karimaneh.Application.Features.Wallets.Queries;
using Karimaneh.Application.Features.Wallets.Specifications;
using Karimaneh.Domain.WalletAgg.Repository;

namespace Karimaneh.Application.Features.Wallets.Handlers
{
    public class GetAllWalletsQueryHandler : IBaseQueryHandler<GetAllWalletsQuery, IEnumerable<WalletResponseDto>>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public GetAllWalletsQueryHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WalletResponseDto>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken)
        {
            var spec = new WalletGetAllSpec(request.Limit, request.Offset);
            var wallets = await _walletRepository.GetAllAsync(spec, cancellationToken);
            return _mapper.Map<IEnumerable<WalletResponseDto>>(wallets);
        }
    }
}
