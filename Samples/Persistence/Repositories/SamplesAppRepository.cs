using System;
using System.Collections.Generic;
using Samples.Core.Models;
using Samples.Core.Repositories;

namespace Samples.Persistence.Repositories
{
    public class SamplesAppRepository : ISamplesAppRepository
    {
        public List<Sample> GetSamples()
        {
            throw new NotImplementedException();
        }

        public List<Sample> GetSamplesByStatus(int statusId)
        {
            throw new NotImplementedException();
        }

        public List<Sample> GetSamplesByNames(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void AddSample()
        {
            throw new NotImplementedException();
        }
    }
}
