using Karimaneh.Domain.LoanAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karimaneh.Infrastructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(t => t.Amount)
                  .HasPrecision(18, 2);
        }
    }
}
