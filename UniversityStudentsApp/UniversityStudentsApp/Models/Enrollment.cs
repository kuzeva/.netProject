using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityStudentsApp.Models
{
    public class Enrollment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int? Semester { get; set; }

        public int? Year { get; set; }

        public int? Grade { get; set; }

        [StringLength(255, MinimumLength = 10)]
        public string SeminarURL { get; set; }

        [StringLength(255, MinimumLength = 10)]
        public string ProjectURL { get; set; }

        public int? ExamPoints { get; set; }

        public int? SeminarPoints { get; set; }

        public int? ProjectPoints { get; set; }

        public int? AditionalPoints { get; set; }

        public DateTime? FinishDate { get; set; }


    }
}
