using Karimaneh.Domain.MemeberAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karimaneh.Infrastructure.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.OwnsOne(o => o.BankInfo, a => { });
            builder.OwnsOne(o => o.PhoneNumber, a => { });
            builder.OwnsOne(o => o.NationalCode, a => { });

            builder.Property(t => t.DebtAmount)
                 .HasPrecision(18, 2);

            builder.Property(t => t.DepositeBalance)
                 .HasPrecision(18, 2);

            builder.Property(t => t.TotalRecivedLoanAmount)
                 .HasPrecision(18, 2);

        }
    }
}
