using System.Collections.Generic;
using Samples.Core.Models;

namespace Samples.Core.Repositories
{
    public interface ISamplesAppRepository
    {
        IEnumerable<Sample> GetSamples(int? status = null, string name = null);
        void AddSample(Sample sample);
        bool SaveAll();
    }
}
