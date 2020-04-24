using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityStudentsApp.Models;

namespace UniversityStudentsApp.ViewModels
{
    public class CourseFilterViewModel
    {
        public IList<Course> Courses { get; set; }
        public SelectList Titles { get; set; }
        public string CourseTitle { get; set; }
        public SelectList Semesters { get; set; }
        public string CourseSemester { get; set; }
        public SelectList Programmes { get; set; }
        public string CourseProgramme { get; set; }

    }
}
