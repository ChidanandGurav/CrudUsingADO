using Microsoft.Build.Framework;

namespace CrudUsingADO.Models
{
    public class Student
    {
        public int RollNo { get; set; }

        [Required]
        public string? Name { get; set; }


        [Required]
        public string? City { get; set; }


        [Required]
        public int Percentage { get; set; }
    }
}
