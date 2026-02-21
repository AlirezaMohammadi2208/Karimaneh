using AutoMapper;
using Karimaneh.Application.Features.Wallets.DTOs;
using Karimaneh.Domain.WalletAgg;

namespace Karimaneh.Application.Features.Wallets.Mappings
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<Wallet, WalletResponseDto>();
        }
    }
}
