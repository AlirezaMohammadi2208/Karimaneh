using Common.Domain.Constract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.MemeberAgg.Repository
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<Member?> GetByWalletIdAsync(Guid walletId, CancellationToken cancellationToken);
        Task AddAsync(Member member, CancellationToken cancellationToken);
    }
}
