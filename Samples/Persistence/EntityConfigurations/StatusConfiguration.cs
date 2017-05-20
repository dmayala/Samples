using Samples.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Samples.Persistence.EntityConfigurations
{
    public class StatusConfiguration : EntityTypeConfiguration<Status>
    {
        public override void Map(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(x => x.StatusId);
            builder.Property(x => x.StatusName)
                .HasColumnName("Status");
        }
    }
}
