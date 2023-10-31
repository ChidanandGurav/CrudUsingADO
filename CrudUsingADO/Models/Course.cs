using Microsoft.Build.Framework;

namespace CrudUsingADO.Models
{
    public class Course
    {
        public int Cid { get; set; }

        [Required]
        public string? CName { get; set; }

        [Required]
        public int Fees { get; set; }

        [Required]
        public string? Duration { get; set; }
    }
}
