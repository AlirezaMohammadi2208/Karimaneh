using Karimaneh.Domain.LoanAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karimaneh.Infrastructure.Persistence.Configurations
{
    public class InstallmentConfiguration : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.Property(t => t.Amount)
                   .HasPrecision(18, 2);
        }
    }
}
