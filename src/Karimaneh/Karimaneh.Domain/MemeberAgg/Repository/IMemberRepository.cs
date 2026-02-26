using Common.Domain.Constract;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Domain.MemeberAgg.Repository
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<Member?> GetByWalletIdAsync(Guid walletId, CancellationToken cancellationToken);
        Task AddAsync(Member member, CancellationToken cancellationToken);
        Task<Member?> GetMemberById(Guid memberId);
        Task<IEnumerable<Member>> GetAllAsync(ISpecification<Member> spec, CancellationToken cancellationToken = default);
        Task<Member?> GetByNationalCodeAsync(NationalCode nationalCode, ISpecification<Member> spec, CancellationToken cancellationToken = default);
        Task<bool> ExistsByNationalCodeAsync(NationalCode nationalCode, CancellationToken cancellationToken);
    }
}
