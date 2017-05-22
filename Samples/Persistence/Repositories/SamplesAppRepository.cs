using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Samples.Core.Models;
using Samples.Core.Repositories;

namespace Samples.Persistence.Repositories
{
    public class SamplesAppRepository : ISamplesAppRepository
    {
        private readonly SamplesAppContext _context;

        public SamplesAppRepository(SamplesAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Sample> GetSamples(int? status = null, string name = null)
        {
            var samples =  _context.Samples
                .Include(s => s.Creator)
                .Include(s => s.Status)
                .AsNoTracking();

            if (status.HasValue)
                samples = samples.Where(s => s.StatusId == status);
     
            if (name != null)
                samples = samples.Where(s => s.Creator.FullName.ToLower().Contains(name.ToLower()));

            return samples;
        }

        public void AddSample(Sample sample)
        {
            _context.Add(sample);
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _context.Statuses;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
