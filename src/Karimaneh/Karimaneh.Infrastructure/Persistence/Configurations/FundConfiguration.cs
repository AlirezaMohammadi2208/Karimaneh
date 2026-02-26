using Karimaneh.Domain.FundAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karimaneh.Infrastructure.Persistence.Configurations
{
    public class FundConfiguration : IEntityTypeConfiguration<Fund>
    {
        public void Configure(EntityTypeBuilder<Fund> builder)
        {
            builder.OwnsOne(o => o.BankInfo, a => { });

            builder.Property(t => t.MinLoanAmount)
               .HasPrecision(18, 2);

            builder.Property(t => t.MaxLoanAmount)
                   .HasPrecision(18, 2);

            builder.Property(t => t.MemberShipFee)
                   .HasPrecision(18, 2);

        }
    }
}
