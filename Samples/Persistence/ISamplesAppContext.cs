using Microsoft.EntityFrameworkCore;
using Samples.Core.Models;

namespace Samples.Persistence
{
    public interface ISamplesAppContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Sample> Samples { get; set; }
    }
}