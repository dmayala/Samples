using Microsoft.EntityFrameworkCore;
using Samples.Core.Models;
using Samples.Persistence.EntityConfigurations;

namespace Samples.Persistence
{
    public class SamplesAppContext : DbContext, ISamplesAppContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Sample> Samples { get; set; }

        public SamplesAppContext(DbContextOptions<SamplesAppContext> options)
                : base((DbContextOptions) options)
            { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddConfiguration(new StatusConfiguration());
            builder.AddConfiguration(new UserConfiguration());
            builder.AddConfiguration(new SampleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
