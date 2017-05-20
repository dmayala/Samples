using System;

namespace Samples.Core.Models
{
    public class Sample
    {
        public int SampleId { get; set; }
        public string Barcode { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int StatusId { get; set; }

        public User Creator { get; set; }
        public Status Status { get; set; }
    }
}
