using Common.Domain.Constract;
using Karimaneh.Domain.MemeberAgg;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Karimaneh.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly KarimanehDbContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public MemberRepository(KarimanehDbContext context)
        {
            _context = context;
        }
        public async Task<Member?> GetByWalletIdAsync(Guid walletId, CancellationToken cancellationToken)
        {
            return await _context.Members.FirstOrDefaultAsync(x => x.WalletId == walletId, cancellationToken);
        }

        public async Task AddAsync(Member member, CancellationToken cancellationToken)
        {
            await _context.AddAsync(member);
        }
    }
}
