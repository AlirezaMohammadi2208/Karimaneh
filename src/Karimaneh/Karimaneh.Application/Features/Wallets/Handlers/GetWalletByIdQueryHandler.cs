using AutoMapper;
using Common.Application.CQRS.Query;
using Common.Application.Exceptions;
using Karimaneh.Application.Features.Wallets.DTOs;
using Karimaneh.Application.Features.Wallets.Queries;
using Karimaneh.Application.Features.Wallets.Specifications;
using Karimaneh.Domain.WalletAgg.Repository;

namespace Karimaneh.Application.Features.Wallets.Handlers
{
    public class GetWalletByIdQueryHandler : IBaseQueryHandler<GetWalletByIdQuery, WalletResponseDto>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public GetWalletByIdQueryHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<WalletResponseDto> Handle(GetWalletByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new WalletGetAllSpec();
            var wallet = await _walletRepository.GetByIdAsync(request.Id, spec, cancellationToken);
            return _mapper.Map<WalletResponseDto>(wallet) ?? throw new NotFoundException("Wallet Account", request.Id);
        }
    }
}
