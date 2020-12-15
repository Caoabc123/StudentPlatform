using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPlatform.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Level { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
