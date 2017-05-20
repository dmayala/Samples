using Samples.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Samples.Persistence.EntityConfigurations
{
    public class SampleConfiguration : EntityTypeConfiguration<Sample>
    {
        public override void Map(EntityTypeBuilder<Sample> builder)
        {
            builder.HasKey(x => x.SampleId);
            builder.HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatedBy);
        }
    }
}
