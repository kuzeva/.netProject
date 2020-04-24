using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityStudentsApp.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string Title { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public int Semester { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Programme { get; set; }

        [StringLength(25, MinimumLength = 5)]
        public string EducationLevel { get; set; }

        public int FirstTeacherId { get; set; }
        [Display(Name = "First Professor")]
        public Teacher FirstTeacher { get; set; }

        public int SecondTeacherId { get; set; }
        [Display(Name = "Second Professor")]
        public Teacher SecondTeacher { get; set; }

        public ICollection<Enrollment> Students { get; set; }

       // public ICollection<Teacher> Teachers { get; set; }
    }
}
