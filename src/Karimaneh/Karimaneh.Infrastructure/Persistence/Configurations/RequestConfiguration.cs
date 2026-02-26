using Karimaneh.Domain.RequestAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karimaneh.Infrastructure.Persistence.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.Property(t => t.Amount)
                 .HasPrecision(18, 2);
        }
    }
}
