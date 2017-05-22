using System.ComponentModel.DataAnnotations;

namespace Samples.Core.Dtos
{
    public class AddSampleDto
    {
        [Required]
        public string Barcode { get; set; }
        [Required]
        public int? CreatedBy { get; set; }
        [Required]
        public int? StatusId { get; set; }
    }
}
