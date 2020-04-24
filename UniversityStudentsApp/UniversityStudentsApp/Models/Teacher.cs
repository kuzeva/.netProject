using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityStudentsApp.Models
{
    public class Teacher
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50,MinimumLength =3)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Degree { get; set; }

        [StringLength(25, MinimumLength = 3)]
        public string AcademicRank { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public string OfficeNumber { get; set; }

        public DateTime HireDate { get; set; }

        [Display(Name = "Professor Full Name")]
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }

        }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Course> FirstTeacherCourses { get; set; }

        public ICollection<Course> SecondTeacherCourses { get; set; }




    }
}
