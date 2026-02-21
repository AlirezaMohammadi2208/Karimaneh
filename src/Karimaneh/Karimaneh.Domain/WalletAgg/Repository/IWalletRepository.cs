using Common.Domain.Constract;

namespace Karimaneh.Domain.WalletAgg.Repository
{
    public interface IWalletRepository : IBaseRepository<Wallet>
    {
        Task<Wallet> AddAsync(Wallet account, CancellationToken cancellationToken = default);
        Task<Wallet?> GetByIdAsync(Guid id, ISpecification<Wallet> spec, CancellationToken cancellationToken = default);
        Task<IEnumerable<Wallet>> GetAllAsync(ISpecification<Wallet> spec, CancellationToken cancellationToken = default);

    }
}
