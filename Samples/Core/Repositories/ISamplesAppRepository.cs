using System.Collections.Generic;
using Samples.Core.Models;

namespace Samples.Core.Repositories
{
    public interface ISamplesAppRepository
    {
        List<Sample> GetSamples();
        List<Sample> GetSamplesByStatus(int statusId);
        List<Sample> GetSamplesByNames(string searchTerm);
        void AddSample();
    }
}
