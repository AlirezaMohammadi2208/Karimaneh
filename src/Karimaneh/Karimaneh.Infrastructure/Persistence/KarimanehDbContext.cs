using Common.Domain.Constract;
using Karimaneh.Domain.Entities;
using Karimaneh.Domain.FundAgg;
using Karimaneh.Domain.LoanAgg;
using Karimaneh.Domain.MemeberAgg;
using Karimaneh.Domain.MessageAgg;
using Karimaneh.Domain.RequestAgg;
using Karimaneh.Domain.TicketAgg;
using Karimaneh.Domain.TransactionAgg;
using Karimaneh.Domain.WalletAgg;
using Karimaneh.Infrastructure.Extensions;
using Karimaneh.Infrastructure.Persistence.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Karimaneh.Infrastructure.Persistence
{
    public class KarimanehDbContext : DbContext, IUnitOfWork
    {
#pragma warning disable CS8618 // Required by Entity Framework
        public KarimanehDbContext(DbContextOptions<KarimanehDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientRequestEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FundConfiguration());
            modelBuilder.ApplyConfiguration(new InstallmentConfiguration());
            modelBuilder.ApplyConfiguration(new LoanConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
        }
        public DbSet<Fund> Funds { get; set; } = default!;
        public DbSet<Installment> Installments { get; set; } = default!;
        public DbSet<Loan> Loans { get; set; } = default!;
        public DbSet<Member> Members { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; } = default!;
        public DbSet<Wallet> Wallets { get; set; } = default!;
        public DbSet<Message> Messages { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;
        public DbSet<Guarantor> Guarantors { get; set; } = default!;
        public DbSet<Request> Requests { get; set; } = default!;
        public DbSet<AuditLog> AuditLogs { get; set; } = default!;

        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;

        public KarimanehDbContext(DbContextOptions<KarimanehDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("KarimanehDbContext::ctor ->" + this.GetHashCode());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            _ = await base.SaveChangesAsync(cancellationToken);

            await _mediator.DispatchDomainEventsAsync(this);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveEntitiesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (HasActiveTransaction)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (HasActiveTransaction)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
