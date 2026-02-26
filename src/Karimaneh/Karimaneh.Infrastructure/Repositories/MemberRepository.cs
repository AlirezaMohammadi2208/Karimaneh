using Common.Domain.Constract;
using Common.Domain.ValueObjects;
using Karimaneh.Domain.MemeberAgg;
using Karimaneh.Domain.MemeberAgg.Repository;
using Karimaneh.Infrastructure.Persistence;
using Karimaneh.Infrastructure.Specifications;
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

        public async Task<Member?> GetMemberById(Guid memberId)
        {
            return await _context.Members.FirstOrDefaultAsync(x => x.Id == memberId);
        }
        public async Task<IEnumerable<Member>> GetAllAsync(ISpecification<Member> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Members.AsQueryable();
            queryable = SpecificationEvaluator<Member>.GetQuery(queryable, spec);
            return await queryable.ToListAsync(cancellationToken);
        }

        public async Task<Member?> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Members
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
        public async Task<Member?> GetByNationalCodeAsync(NationalCode nationalCode, ISpecification<Member> spec, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Members.AsQueryable();
            queryable = SpecificationEvaluator<Member>.GetQuery(queryable, spec);
            return await queryable.FirstOrDefaultAsync(e => e.NationalCode == nationalCode, cancellationToken);
        }
        public async Task<bool> ExistsByNationalCodeAsync(NationalCode nationalCode, CancellationToken cancellationToken)
        {
            return await _context.Members
                     .AsNoTracking()
                     .AnyAsync(e => e.NationalCode == nationalCode, cancellationToken);
        }
    }
}
