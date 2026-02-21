using Common.Application.CQRS.Query;
using Karimaneh.Application.Features.Wallets.DTOs;

namespace Karimaneh.Application.Features.Wallets.Queries
{
    public class GetWalletByIdQuery : IBaseQuery<WalletResponseDto>
    {
        public Guid Id { get; set; }
    }
}
